﻿using System;
using System.Collections;

namespace Data_Structures.Array;
public partial class Array : IEnumerable
{
    // Object
    // Type : Array

    #region notlar
    //Diziler-Array'ler STATİKTİR.
    //Dizilerin sağladığı en büyük avantaj;
    //    *  RAM(Random Access Memory)dir. İlgili alana doğrudan erişim sağlayabilme olanağımız vardır. Rastgele istediğimiz göze hızlıca doğrudan erişim hakkı tanır. O(1)
    #endregion

    private Object[] _InnerArray; // null
    private int index = 0;
    public int Count => index;  // Dizi kaç eleman var? //sadece get kullandık
    public int Capacity => _InnerArray.Length; //sadece get kullandık // -  get; set; -> ACCESSOR denir


    public Array()
    {   //eğer ctor içinde tanımlanan diziyi oluşturmazsak dışarda new'lenmesini bekleyeceği için null olma durumu için uyarı gösterir
        _InnerArray = new Object[4]; // Block allocation
    }

    public Array(params Object[] init) //overloading //bu şekilde oluşturulan instancelarda count ve capasity propları değişkenlik gösteriyor index field'ından ötürü.
    {
        var newArray = new Object[init.Length];
        System.Array.Copy(init, newArray, init.Length);
        _InnerArray = newArray;
    } //teori-week2

    public void Add(Object item)
    {
        if(index==_InnerArray.Length)
        {
            DoubleArray(_InnerArray);
        }
        
        _InnerArray[index] = item;
        index++;
    }//teori-week1

    private void DoubleArray(object[] array)
    {
        var newArray = new Object[array.Length * 2];
        System.Array.Copy(array, newArray, array.Length);
        _InnerArray = newArray;
    }//teori-week1

    /// <summary>
    /// Week 1
    /// </summary>
    /// <param name="position"></param>
    /// <returns>
    ///     Verilen pozisyonda bulunan elemanı geri döndürür.
    ///     Eğer pozisyon sınırlar dışındaysa IndexOutOfRangeException hata fırlatır.
    /// </returns>
    /// <exception cref="NotImplementedException"></exception>
    public Object GetItem(int position)
    {
        // throw new NotImplementedException();
        if (position < 0 || position >= _InnerArray.Length)
            throw new IndexOutOfRangeException();
        return _InnerArray[position];
    }//LAB-week1

    /// <summary>
    /// Week 2 - Implematation 1
    /// SetItem içerisinde verilen pozisyon değeri aralık dışarısında ise hata fırlatılmalı.
    /// Exception() // IndexOutOfRangeException()
    /// </summary>
    /// <param name="position"></param>
    /// <param name="item"></param>
    public void SetItem(int position, Object item)
    {
        if (position < 0 || position >= _InnerArray.Length)
            throw new IndexOutOfRangeException();
        _InnerArray[position] = item;
    }//teori-week2

    /// <summary>
    /// Week 2 - Implementation 2 
    /// Remove işleminde girilen pozisyondaki eleman çıkarılmalıdır.
    /// Çıkarma işleminden sonra eleman geri döndürülmelidir.
    /// Çıkarılan elemanın yerine diğerleri kaydırılmalıdır.
    /// </summary>
    /// <param name="position"></param>
    /// <exception cref="NotImplementedException"></exception>
    public Object RemoveItem(int position)
    {
        var item = GetItem(position);
        SetItem(position, null);
        for(int i=position; i< Count-1; i++)
        {
            // _InnerArray[i] = _InnerArray[i + 1];
            Swap(i, i + 1);
        }
        index--;
        if(index == _InnerArray.Length / 2)
        {
            var newArray = new Object[_InnerArray.Length / 2];
            System.Array.Copy(_InnerArray, newArray, newArray.Length);
            _InnerArray = newArray;
        }
        return item;
    }//LAB-week1

    /// <summary>
    ///  Week - 1 Implementation 2
    /// </summary>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    public void Swap(int p1, int p2)//verilen konum bilgileri p1 ile p2 olan elemanların yerlerini değiştiren metot
    {
        var temp = _InnerArray[p1];
        _InnerArray[p1] = _InnerArray[p2];
        _InnerArray[p2] = temp;
    }//LAB-week1

    /// <summary>
    /// Week - 1 Implementation 3
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public int Find(Object item)//listenin içinde verilen elemanı bulan metot
    {
        for (int i = 0; i < _InnerArray.Length; i++)
        {
            if (item.Equals(_InnerArray[i])) // DİKKAT !!! koşul (o == _InnerArray[i] yazabilirdik ama bu şekilde veri türünü kontrol edememiş oluruz!!!
            {
                return i;
            }
        }
        return -1; // verdiğimiz elemanı bulamazsa -1 döndürsün
    }//LAB-week1

    /// <summary>
    /// Week 2 - Implementation 3
    /// Verilen değer aralındaki elemanlar kopyalanmalıdır.
    /// Geri dönüş değeri dizidir.
    /// Verilen pozisyon bilgileri kontrol edilmelidir.
    /// </summary>
    /// <returns></returns>
    public Object[] Copy(int v1, int v2) //bir dizinin bir kısmını veya tamamını bir başka diziye kopyalayan metot
    {
        // sayilar = {a, b, c, d, e, f, g};
        // numbers = sayilar.Copy(2, 4);  -->  istenen = {c, d}

        var newArray = new Object[v2]; // v2 - v1
        int yeniIndex = 0;
        for(int i=v1; i < v2; i++)
        {
            newArray[yeniIndex] = GetItem(i); // Object
            yeniIndex++;
        } //LAB-week2

        return newArray;
    }

    public IEnumerator GetEnumerator()
    {
        return _InnerArray.GetEnumerator();
    }//teori-week2 !!!!!!!!!!


}
