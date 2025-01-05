/* ----------------------------------------------------------------------------
 * This file was automatically generated by SWIG (http://www.swig.org).
 * Version 2.0.12
 *
 * Do not make changes to this file unless you know what you are doing--modify
 * the SWIG interface file instead.
 * ----------------------------------------------------------------------------- */

namespace OdeLibrary {

using System;
using System.Runtime.InteropServices;

public class StateType : IDisposable, System.Collections.IEnumerable
#if !SWIG_DOTNET_1
    , System.Collections.Generic.IList<double>
#endif
 {
  private HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal StateType(IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new HandleRef(this, cPtr);
  }

  internal static HandleRef getCPtr(StateType obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  ~StateType() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          CorePINVOKE.delete_StateType(swigCPtr);
        }
        swigCPtr = new HandleRef(null, IntPtr.Zero);
      }
      GC.SuppressFinalize(this);
    }
  }

  public StateType(System.Collections.ICollection c) : this() {
    if (c == null)
      throw new ArgumentNullException("c");
    foreach (double element in c) {
      this.Add(element);
    }
  }

  public bool IsFixedSize {
    get {
      return false;
    }
  }

  public bool IsReadOnly {
    get {
      return false;
    }
  }

  public double this[int index]  {
    get {
      return getitem(index);
    }
    set {
      setitem(index, value);
    }
  }

  public int Capacity {
    get {
      return (int)capacity();
    }
    set {
      if (value < size())
        throw new ArgumentOutOfRangeException("Capacity");
      reserve((uint)value);
    }
  }

  public int Count {
    get {
      return (int)size();
    }
  }

  public bool IsSynchronized {
    get {
      return false;
    }
  }

#if SWIG_DOTNET_1
  public void CopyTo(System.Array array)
#else
  public void CopyTo(double[] array)
#endif
  {
    CopyTo(0, array, 0, this.Count);
  }

#if SWIG_DOTNET_1
  public void CopyTo(System.Array array, int arrayIndex)
#else
  public void CopyTo(double[] array, int arrayIndex)
#endif
  {
    CopyTo(0, array, arrayIndex, this.Count);
  }

#if SWIG_DOTNET_1
  public void CopyTo(int index, System.Array array, int arrayIndex, int count)
#else
  public void CopyTo(int index, double[] array, int arrayIndex, int count)
#endif
  {
    if (array == null)
      throw new ArgumentNullException("array");
    if (index < 0)
      throw new ArgumentOutOfRangeException("index", "Value is less than zero");
    if (arrayIndex < 0)
      throw new ArgumentOutOfRangeException("arrayIndex", "Value is less than zero");
    if (count < 0)
      throw new ArgumentOutOfRangeException("count", "Value is less than zero");
    if (array.Rank > 1)
      throw new ArgumentException("Multi dimensional array.", "array");
    if (index+count > this.Count || arrayIndex+count > array.Length)
      throw new ArgumentException("Number of elements to copy is too large.");
    for (int i=0; i<count; i++)
      array.SetValue(getitemcopy(index+i), arrayIndex+i);
  }

#if !SWIG_DOTNET_1
  System.Collections.Generic.IEnumerator<double> System.Collections.Generic.IEnumerable<double>.GetEnumerator() {
    return new StateTypeEnumerator(this);
  }
#endif

  System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
    return new StateTypeEnumerator(this);
  }

  public StateTypeEnumerator GetEnumerator() {
    return new StateTypeEnumerator(this);
  }

  // Type-safe enumerator
  /// Note that the IEnumerator documentation requires an InvalidOperationException to be thrown
  /// whenever the collection is modified. This has been done for changes in the size of the
  /// collection but not when one of the elements of the collection is modified as it is a bit
  /// tricky to detect unmanaged code that modifies the collection under our feet.
  public sealed class StateTypeEnumerator : System.Collections.IEnumerator
#if !SWIG_DOTNET_1
    , System.Collections.Generic.IEnumerator<double>
#endif
  {
    private StateType collectionRef;
    private int currentIndex;
    private object currentObject;
    private int currentSize;

    public StateTypeEnumerator(StateType collection) {
      collectionRef = collection;
      currentIndex = -1;
      currentObject = null;
      currentSize = collectionRef.Count;
    }

    // Type-safe iterator Current
    public double Current {
      get {
        if (currentIndex == -1)
          throw new InvalidOperationException("Enumeration not started.");
        if (currentIndex > currentSize - 1)
          throw new InvalidOperationException("Enumeration finished.");
        if (currentObject == null)
          throw new InvalidOperationException("Collection modified.");
        return (double)currentObject;
      }
    }

    // Type-unsafe IEnumerator.Current
    object System.Collections.IEnumerator.Current {
      get {
        return Current;
      }
    }

    public bool MoveNext() {
      int size = collectionRef.Count;
      bool moveOkay = (currentIndex+1 < size) && (size == currentSize);
      if (moveOkay) {
        currentIndex++;
        currentObject = collectionRef[currentIndex];
      } else {
        currentObject = null;
      }
      return moveOkay;
    }

    public void Reset() {
      currentIndex = -1;
      currentObject = null;
      if (collectionRef.Count != currentSize) {
        throw new InvalidOperationException("Collection modified.");
      }
    }

#if !SWIG_DOTNET_1
    public void Dispose() {
        currentIndex = -1;
        currentObject = null;
    }
#endif
  }

  public void Clear() {
    CorePINVOKE.StateType_Clear(swigCPtr);
  }

  public void Add(double x) {
    CorePINVOKE.StateType_Add(swigCPtr, x);
  }

  private uint size() {
    uint ret = CorePINVOKE.StateType_size(swigCPtr);
    return ret;
  }

  private uint capacity() {
    uint ret = CorePINVOKE.StateType_capacity(swigCPtr);
    return ret;
  }

  private void reserve(uint n) {
    CorePINVOKE.StateType_reserve(swigCPtr, n);
  }

  public StateType() : this(CorePINVOKE.new_StateType__SWIG_0(), true) {
  }

  public StateType(StateType other) : this(CorePINVOKE.new_StateType__SWIG_1(StateType.getCPtr(other)), true) {
    if (CorePINVOKE.SWIGPendingException.Pending) throw CorePINVOKE.SWIGPendingException.Retrieve();
  }

  public StateType(int capacity) : this(CorePINVOKE.new_StateType__SWIG_2(capacity), true) {
    if (CorePINVOKE.SWIGPendingException.Pending) throw CorePINVOKE.SWIGPendingException.Retrieve();
  }

  private double getitemcopy(int index) {
    double ret = CorePINVOKE.StateType_getitemcopy(swigCPtr, index);
    if (CorePINVOKE.SWIGPendingException.Pending) throw CorePINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  private double getitem(int index) {
    double ret = CorePINVOKE.StateType_getitem(swigCPtr, index);
    if (CorePINVOKE.SWIGPendingException.Pending) throw CorePINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  private void setitem(int index, double val) {
    CorePINVOKE.StateType_setitem(swigCPtr, index, val);
    if (CorePINVOKE.SWIGPendingException.Pending) throw CorePINVOKE.SWIGPendingException.Retrieve();
  }

  public void AddRange(StateType values) {
    CorePINVOKE.StateType_AddRange(swigCPtr, StateType.getCPtr(values));
    if (CorePINVOKE.SWIGPendingException.Pending) throw CorePINVOKE.SWIGPendingException.Retrieve();
  }

  public StateType GetRange(int index, int count) {
    IntPtr cPtr = CorePINVOKE.StateType_GetRange(swigCPtr, index, count);
    StateType ret = (cPtr == IntPtr.Zero) ? null : new StateType(cPtr, true);
    if (CorePINVOKE.SWIGPendingException.Pending) throw CorePINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public void Insert(int index, double x) {
    CorePINVOKE.StateType_Insert(swigCPtr, index, x);
    if (CorePINVOKE.SWIGPendingException.Pending) throw CorePINVOKE.SWIGPendingException.Retrieve();
  }

  public void InsertRange(int index, StateType values) {
    CorePINVOKE.StateType_InsertRange(swigCPtr, index, StateType.getCPtr(values));
    if (CorePINVOKE.SWIGPendingException.Pending) throw CorePINVOKE.SWIGPendingException.Retrieve();
  }

  public void RemoveAt(int index) {
    CorePINVOKE.StateType_RemoveAt(swigCPtr, index);
    if (CorePINVOKE.SWIGPendingException.Pending) throw CorePINVOKE.SWIGPendingException.Retrieve();
  }

  public void RemoveRange(int index, int count) {
    CorePINVOKE.StateType_RemoveRange(swigCPtr, index, count);
    if (CorePINVOKE.SWIGPendingException.Pending) throw CorePINVOKE.SWIGPendingException.Retrieve();
  }

  public static StateType Repeat(double value, int count) {
    IntPtr cPtr = CorePINVOKE.StateType_Repeat(value, count);
    StateType ret = (cPtr == IntPtr.Zero) ? null : new StateType(cPtr, true);
    if (CorePINVOKE.SWIGPendingException.Pending) throw CorePINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public void Reverse() {
    CorePINVOKE.StateType_Reverse__SWIG_0(swigCPtr);
  }

  public void Reverse(int index, int count) {
    CorePINVOKE.StateType_Reverse__SWIG_1(swigCPtr, index, count);
    if (CorePINVOKE.SWIGPendingException.Pending) throw CorePINVOKE.SWIGPendingException.Retrieve();
  }

  public void SetRange(int index, StateType values) {
    CorePINVOKE.StateType_SetRange(swigCPtr, index, StateType.getCPtr(values));
    if (CorePINVOKE.SWIGPendingException.Pending) throw CorePINVOKE.SWIGPendingException.Retrieve();
  }

  public bool Contains(double value) {
    bool ret = CorePINVOKE.StateType_Contains(swigCPtr, value);
    return ret;
  }

  public int IndexOf(double value) {
    int ret = CorePINVOKE.StateType_IndexOf(swigCPtr, value);
    return ret;
  }

  public int LastIndexOf(double value) {
    int ret = CorePINVOKE.StateType_LastIndexOf(swigCPtr, value);
    return ret;
  }

  public bool Remove(double value) {
    bool ret = CorePINVOKE.StateType_Remove(swigCPtr, value);
    return ret;
  }

}

}
