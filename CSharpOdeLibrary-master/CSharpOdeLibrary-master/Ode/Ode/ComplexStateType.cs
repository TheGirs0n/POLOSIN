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

public class ComplexStateType : IDisposable, System.Collections.IEnumerable
#if !SWIG_DOTNET_1
    , System.Collections.Generic.IEnumerable<Complex>
#endif
 {
  private HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal ComplexStateType(IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new HandleRef(this, cPtr);
  }

  internal static HandleRef getCPtr(ComplexStateType obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  ~ComplexStateType() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          CorePINVOKE.delete_ComplexStateType(swigCPtr);
        }
        swigCPtr = new HandleRef(null, IntPtr.Zero);
      }
      GC.SuppressFinalize(this);
    }
  }

  public ComplexStateType(System.Collections.ICollection c) : this() {
    if (c == null)
      throw new ArgumentNullException("c");
    foreach (Complex element in c) {
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

  public Complex this[int index]  {
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
  public void CopyTo(Complex[] array)
#endif
  {
    CopyTo(0, array, 0, this.Count);
  }

#if SWIG_DOTNET_1
  public void CopyTo(System.Array array, int arrayIndex)
#else
  public void CopyTo(Complex[] array, int arrayIndex)
#endif
  {
    CopyTo(0, array, arrayIndex, this.Count);
  }

#if SWIG_DOTNET_1
  public void CopyTo(int index, System.Array array, int arrayIndex, int count)
#else
  public void CopyTo(int index, Complex[] array, int arrayIndex, int count)
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
  System.Collections.Generic.IEnumerator<Complex> System.Collections.Generic.IEnumerable<Complex>.GetEnumerator() {
    return new ComplexStateTypeEnumerator(this);
  }
#endif

  System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
    return new ComplexStateTypeEnumerator(this);
  }

  public ComplexStateTypeEnumerator GetEnumerator() {
    return new ComplexStateTypeEnumerator(this);
  }

  // Type-safe enumerator
  /// Note that the IEnumerator documentation requires an InvalidOperationException to be thrown
  /// whenever the collection is modified. This has been done for changes in the size of the
  /// collection but not when one of the elements of the collection is modified as it is a bit
  /// tricky to detect unmanaged code that modifies the collection under our feet.
  public sealed class ComplexStateTypeEnumerator : System.Collections.IEnumerator
#if !SWIG_DOTNET_1
    , System.Collections.Generic.IEnumerator<Complex>
#endif
  {
    private ComplexStateType collectionRef;
    private int currentIndex;
    private object currentObject;
    private int currentSize;

    public ComplexStateTypeEnumerator(ComplexStateType collection) {
      collectionRef = collection;
      currentIndex = -1;
      currentObject = null;
      currentSize = collectionRef.Count;
    }

    // Type-safe iterator Current
    public Complex Current {
      get {
        if (currentIndex == -1)
          throw new InvalidOperationException("Enumeration not started.");
        if (currentIndex > currentSize - 1)
          throw new InvalidOperationException("Enumeration finished.");
        if (currentObject == null)
          throw new InvalidOperationException("Collection modified.");
        return (Complex)currentObject;
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
    CorePINVOKE.ComplexStateType_Clear(swigCPtr);
  }

  public void Add(Complex x) {
    CorePINVOKE.ComplexStateType_Add(swigCPtr, Complex.getCPtr(x));
    if (CorePINVOKE.SWIGPendingException.Pending) throw CorePINVOKE.SWIGPendingException.Retrieve();
  }

  private uint size() {
    uint ret = CorePINVOKE.ComplexStateType_size(swigCPtr);
    return ret;
  }

  private uint capacity() {
    uint ret = CorePINVOKE.ComplexStateType_capacity(swigCPtr);
    return ret;
  }

  private void reserve(uint n) {
    CorePINVOKE.ComplexStateType_reserve(swigCPtr, n);
  }

  public ComplexStateType() : this(CorePINVOKE.new_ComplexStateType__SWIG_0(), true) {
  }

  public ComplexStateType(ComplexStateType other) : this(CorePINVOKE.new_ComplexStateType__SWIG_1(ComplexStateType.getCPtr(other)), true) {
    if (CorePINVOKE.SWIGPendingException.Pending) throw CorePINVOKE.SWIGPendingException.Retrieve();
  }

  public ComplexStateType(int capacity) : this(CorePINVOKE.new_ComplexStateType__SWIG_2(capacity), true) {
    if (CorePINVOKE.SWIGPendingException.Pending) throw CorePINVOKE.SWIGPendingException.Retrieve();
  }

  private Complex getitemcopy(int index) {
    Complex ret = new Complex(CorePINVOKE.ComplexStateType_getitemcopy(swigCPtr, index), true);
    if (CorePINVOKE.SWIGPendingException.Pending) throw CorePINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  private Complex getitem(int index) {
    Complex ret = new Complex(CorePINVOKE.ComplexStateType_getitem(swigCPtr, index), false);
    if (CorePINVOKE.SWIGPendingException.Pending) throw CorePINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  private void setitem(int index, Complex val) {
    CorePINVOKE.ComplexStateType_setitem(swigCPtr, index, Complex.getCPtr(val));
    if (CorePINVOKE.SWIGPendingException.Pending) throw CorePINVOKE.SWIGPendingException.Retrieve();
  }

  public void AddRange(ComplexStateType values) {
    CorePINVOKE.ComplexStateType_AddRange(swigCPtr, ComplexStateType.getCPtr(values));
    if (CorePINVOKE.SWIGPendingException.Pending) throw CorePINVOKE.SWIGPendingException.Retrieve();
  }

  public ComplexStateType GetRange(int index, int count) {
    IntPtr cPtr = CorePINVOKE.ComplexStateType_GetRange(swigCPtr, index, count);
    ComplexStateType ret = (cPtr == IntPtr.Zero) ? null : new ComplexStateType(cPtr, true);
    if (CorePINVOKE.SWIGPendingException.Pending) throw CorePINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public void Insert(int index, Complex x) {
    CorePINVOKE.ComplexStateType_Insert(swigCPtr, index, Complex.getCPtr(x));
    if (CorePINVOKE.SWIGPendingException.Pending) throw CorePINVOKE.SWIGPendingException.Retrieve();
  }

  public void InsertRange(int index, ComplexStateType values) {
    CorePINVOKE.ComplexStateType_InsertRange(swigCPtr, index, ComplexStateType.getCPtr(values));
    if (CorePINVOKE.SWIGPendingException.Pending) throw CorePINVOKE.SWIGPendingException.Retrieve();
  }

  public void RemoveAt(int index) {
    CorePINVOKE.ComplexStateType_RemoveAt(swigCPtr, index);
    if (CorePINVOKE.SWIGPendingException.Pending) throw CorePINVOKE.SWIGPendingException.Retrieve();
  }

  public void RemoveRange(int index, int count) {
    CorePINVOKE.ComplexStateType_RemoveRange(swigCPtr, index, count);
    if (CorePINVOKE.SWIGPendingException.Pending) throw CorePINVOKE.SWIGPendingException.Retrieve();
  }

  public static ComplexStateType Repeat(Complex value, int count) {
    IntPtr cPtr = CorePINVOKE.ComplexStateType_Repeat(Complex.getCPtr(value), count);
    ComplexStateType ret = (cPtr == IntPtr.Zero) ? null : new ComplexStateType(cPtr, true);
    if (CorePINVOKE.SWIGPendingException.Pending) throw CorePINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public void Reverse() {
    CorePINVOKE.ComplexStateType_Reverse__SWIG_0(swigCPtr);
  }

  public void Reverse(int index, int count) {
    CorePINVOKE.ComplexStateType_Reverse__SWIG_1(swigCPtr, index, count);
    if (CorePINVOKE.SWIGPendingException.Pending) throw CorePINVOKE.SWIGPendingException.Retrieve();
  }

  public void SetRange(int index, ComplexStateType values) {
    CorePINVOKE.ComplexStateType_SetRange(swigCPtr, index, ComplexStateType.getCPtr(values));
    if (CorePINVOKE.SWIGPendingException.Pending) throw CorePINVOKE.SWIGPendingException.Retrieve();
  }

}

}
