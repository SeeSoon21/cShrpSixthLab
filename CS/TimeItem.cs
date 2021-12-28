using System;
using System.Text;

namespace just_try
{
    [Serializable]
    public class TimeItem
    {
        public int matrixOrder;
        public int repetition;
        public long CSTime;
        public double CPPTime;
        public double coefficient;

        public TimeItem(int matrixOrder, int repetitionsCount, long CSTime, double CPPTime)
        {
            this.matrixOrder = matrixOrder;
            this.repetition = repetitionsCount;
            this.CSTime = CSTime;
            this.CPPTime = CPPTime;
            this.coefficient = CSTime / CPPTime;
        }
        public override string ToString()
        {
            StringBuilder myStr = new StringBuilder();
            myStr.Append($"Порядок матрица: {matrixOrder}\n");
            myStr.Append($"Номер повторения: {repetition}\n");
            myStr.Append($"Время C#: {CSTime}\n");
            myStr.Append($"Время C++: {CPPTime}\n");
            myStr.Append($"Отношение времени c#/c++: {coefficient}\n\n");

            return myStr.ToString();
        }
    }
}