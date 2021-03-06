// CodeContracts
// 
// Copyright (c) Microsoft Corporation
// 
// All rights reserved. 
// 
// MIT License
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED *AS IS*, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

using System;
using System.Diagnostics.Contracts;


namespace System.Collections
{
  [ContractClass(typeof(ICollectionContract))]
  public interface ICollection
  {
    int Count
    {
      get;
    }

    bool IsSynchronized
    {
      get;
    }

    object SyncRoot
    {
      get;
    }

    void CopyTo(Array array, int index);

  }
  [ContractClassFor(typeof(ICollection))]
  abstract class ICollectionContract : ICollection
  {
    #region ICollection Members

    public int Count
    {
      get
      {
        Contract.Ensures(Contract.Result<int>() >= 0);
        return default(int);
      }
    }

    bool ICollection.IsSynchronized
    {
      get { return false; }
    }

    object ICollection.SyncRoot
    {
      get
      {
        Contract.Ensures(Contract.Result<object>() != null);
        return default(object);
      }
    }

    void ICollection.CopyTo(Array array, int index)
    {
      Contract.Requires(array != null);
      Contract.Requires(array.Rank == 1);
      Contract.Requires(index >= 0);
      Contract.Requires(index <= array.Length - this.Count);
    }

    #endregion
  }
}
