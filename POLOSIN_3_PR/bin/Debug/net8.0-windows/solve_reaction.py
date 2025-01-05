import json
import re
import numpy as np
from scipy.integrate import solve_ivp


# Функция для парсинга химического уравнения
def parse_equation(eq_str):
    """
    Парсит химическое уравнение и возвращает реагенты, продукты и их коэффициенты.
    Уравнение должно быть в формате: "aA + bB -> cC + dD"
    """
    reactants, products = eq_str.split("=")

    # Функция для извлечения компонентов и коэффициентов
    def parse_side(side):
        components = []
        for part in side.split("+"):
            part = part.strip()
            if part == "":
                continue
            # Ищем коэффициент и компонент
            match = re.match(r"(\d*)([A-Za-z]+)", part)
            coeff = match.group(1)
            coeff = int(coeff) if coeff else 1  # Если коэффициент не указан, он равен 1
            component = match.group(2)
            components.append((component, coeff))
        return components

    reactants = parse_side(reactants)
    products = parse_side(products)

    return reactants, products


# Функция для создания системы дифференциальных уравнений
def create_ode_system(equations, rate_constants):
    """
    Создает систему дифференциальных уравнений на основе уравнений и констант скорости.
    """
    components = set()
    for eq in equations:
        reactants, products = parse_equation(eq)
        components.update([r[0] for r in reactants] + [p[0] for p in products])

    component_to_index = {comp: i for i, comp in enumerate(components)}
    num_components = len(components)

    def system(t, y):
        dydt = np.zeros(num_components)

        for eq, k in zip(equations, rate_constants):
            reactants, products = parse_equation(eq)

            # Вычисляем скорость реакции
            rate = k
            for comp, coeff in reactants:
                rate *= y[component_to_index[comp]] ** coeff

            # Обновляем производные для реагентов и продуктов
            for comp, coeff in reactants:
                dydt[component_to_index[comp]] -= coeff * rate
            for comp, coeff in products:
                dydt[component_to_index[comp]] += coeff * rate

        return dydt

    return system, component_to_index


# Основной код
if __name__ == "__main__":
    # Чтение данных из JSON-файла
    input_path = "C:/Users/Timur/Desktop/POLOSIN_3/POLOSIN_3_PR/bin/Debug/net8.0-windows/input.json"
    with open(input_path, "r") as f:
        data = json.load(f)

    equations = data["Equations"]
    rate_constants = data["RateConstants"]
    time = data["Time"]
    time_step = data["TimeStep"]

    # Создаем систему дифференциальных уравнений
    system, component_to_index = create_ode_system(equations, rate_constants)

    # Начальные условия (концентрации компонентов)
    y0 = np.zeros(len(component_to_index))
    for comp in component_to_index:
        y0[component_to_index[comp]] = 1.0  # Начальная концентрация 1.0 для всех компонентов

    # Временной интервал
    t_span = (0, time)
    t_eval = np.arange(0, time + time_step, time_step)

    # Решаем систему дифференциальных уравнений
    sol = solve_ivp(system, t_span, y0, method='RK45', t_eval=t_eval)

    # Сохраняем результаты в файл
    results = {comp: sol.y[idx].tolist() for comp, idx in component_to_index.items()}
    results["time"] = sol.t.tolist()

    output_path = "C:/Users/Timur/Desktop/POLOSIN_3/POLOSIN_3_PR/bin/Debug/net8.0-windows/output.json"
    with open(output_path, "w") as f:
        json.dump(results, f, indent=4)

