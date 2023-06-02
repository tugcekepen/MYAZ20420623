using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structures.Array
{
    public partial class Array : IEnumerable
    {
        /// <summary>
        /// Concate fonksiyonu parametre olarak aldığı array ifadesini 
        /// mevcut dizi yapısı ile birleştirmelidir. 
        /// Örneğin: Array tipindeki numbers = [1,2,3] tanımlansın.
        /// numbers.Concate([4,5]) şeklinde bir komut verildiğinde 
        /// Çıktı : [1,2,3,4,5] olmalıdır. 
        /// </summary>
        /// <param name="array">Birleştirilecek diziyi temsil eder.</param>
        /// 

        public void Concate(Object[] array)
        {
            Object[] newArray = new Object[_InnerArray.Length + array.Length];
            for (int i = 0; i < _InnerArray.Length; i++)
            {
                if (_InnerArray[i] == null)
                {
                    int ind = 0;
                    for (int j = i; j < array.Length + i; j++)
                    {
                        newArray[j] = array[ind];
                        ind++;
                    }
                    break;
                }
                newArray[i] = _InnerArray[i];
            }
            _InnerArray = newArray;
        }

    }
}
