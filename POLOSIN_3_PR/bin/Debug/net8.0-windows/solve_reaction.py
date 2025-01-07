import json
import sys
import numpy as np
from scipy.integrate import solve_ivp
import re


try:
    input_path = "C:/Users/Timur/Desktop/POLOSIN_3/POLOSIN_3_PR/bin/Debug/net8.0-windows/input.json"
    with open(input_path, "r") as f:
        data = json.load(f)

    equations = data["Equations"]
    rate_constants = data["RateConstants"]
    time = data["Time"]
    time_step = data["TimeStep"]
    initial_concentrations = data["InitialConcentrations"]  # Список начальных концентраций

    print("Данные успешно загружены из input.json")
except FileNotFoundError:
    print(f"Файл {input_path} не найден.")
    sys.exit(1)
except Exception as e:
    print(f"Ошибка при чтении файла: {e}")
    sys.exit(1)


# Функция для парсинга химического уравнения
def parse_equation(eq_str):
    reactants, products = eq_str.split("=")

    def parse_side(side):
        components = []
        for part in side.split("+"):
            part = part.strip()
            if part == "":
                continue
            match = re.match(r"(\d*)([A-Za-z]+)", part)
            coeff = match.group(1)
            coeff = int(coeff) if coeff else 1
            component = match.group(2)
            components.append((component, coeff))
        return components

    reactants = parse_side(reactants)
    products = parse_side(products)
    return reactants, products


# Функция для создания системы дифференциальных уравнений
def create_ode_system(equations, rate_constants):
    components = set()
    for eq in equations:
        reactants, products = parse_equation(eq)
        components.update([r[0] for r in reactants] + [p[0] for p in products])

    # Сортируем компоненты для сохранения порядка
    components = sorted(components)
    component_to_index = {comp: i for i, comp in enumerate(components)}
    num_components = len(components)

    def system(t, y):
        # Выводим текущее время и концентрации
        print(f"Время: {t}")
        for comp, idx in component_to_index.items():
            print(f"{comp}: {y[idx]}")

            # Вычисляем производные
        dydt = np.zeros(num_components)
        for eq, k in zip(equations, rate_constants):
            reactants, products = parse_equation(eq)
            rate = k
            for comp, coeff in reactants:
                rate *= y[component_to_index[comp]] ** coeff
            for comp, coeff in reactants:
                dydt[component_to_index[comp]] -= coeff * rate
            for comp, coeff in products:
                dydt[component_to_index[comp]] += coeff * rate

        return dydt

    return system, component_to_index, components


# Создаем систему дифференциальных уравнений
system, component_to_index, components = create_ode_system(equations, rate_constants)

# Проверка индексов


# Начальные условия (концентрации компонентов)
if isinstance(initial_concentrations, list):
    if len(initial_concentrations) == len(components):
        y0 = np.array(initial_concentrations)  # Используем список начальных концентраций
    else:

        sys.exit(1)
else:

    sys.exit(1)

# Временной интервал
t_span = (0, time)  # Временной интервал: от 0 до time
t_eval = np.linspace(0, time, int(time / time_step) + 1)  # Шаг по времени
print(t_span)
print(t_eval)
# Решаем систему дифференциальных уравнений
sol = solve_ivp(system, t_span, y0, method='RK45', t_eval=t_eval)

# Сохраняем результаты в файл
results = {comp: sol.y[idx].tolist() for comp, idx in component_to_index.items()}
results["time"] = sol.t.tolist()

output_path = "C:/Users/Timur/Desktop/POLOSIN_3/POLOSIN_3_PR/bin/Debug/net8.0-windows/output.json"

with open(output_path, "w") as f:
    json.dump(results, f, indent=4)

