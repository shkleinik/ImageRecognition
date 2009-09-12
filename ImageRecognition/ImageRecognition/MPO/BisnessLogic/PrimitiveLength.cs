using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MPO.BisnessLogic
{
    public class PrimitiveLength
    {
        public const int maxPrimitiveLength = 15;

        public static double[] ExecuteAlgorithm(DataGridView dataGrid)
        {
            List<PrimitiveColorLength> list = ScanGridForPrimitives(dataGrid);
            List<int> allColors = GetAllColorsInList(list);
            List<int> allLengths = GetAllLengthsInList(list);

            var resultKoefs = new double[3];
            resultKoefs[0] = CountP1(list, allColors, allLengths);
            resultKoefs[1] = CountP2(list, allColors, allLengths);
            resultKoefs[2] = CountP3(list, allColors, allLengths);
            return resultKoefs;
        }

        public static double GetCompareKoef(double[] templateKoefs, double[] withWhatKoefs)
        {
            return
                Math.Sqrt(Math.Pow(templateKoefs[0] - withWhatKoefs[0], 2) +
                          Math.Pow(templateKoefs[1] - withWhatKoefs[1], 2) +
                          Math.Pow(templateKoefs[2] - withWhatKoefs[2], 2));
        }

        public static List<PrimitiveColorLength> ScanGridForPrimitives(DataGridView dataGrid)
        {
            var list = new List<PrimitiveColorLength>();
            int i = 0;
            int j = 0;
            while (true)
            {
                string result = "";
                result += GoOneIteration(dataGrid, i, j, list);
                result += " \n ";
                j++;
                if (j >= dataGrid.Rows.Count)
                {
                    j = dataGrid.Rows.Count - 1;
                    i++;
                    if (i > dataGrid.Columns.Count)
                    {
                        break;
                    }
                }
            }
            //Console.WriteLine(result);
            PrintAllPrimitives(list);
            return list;
        }

        private static string GoOneIteration(DataGridView dataGrid, int i, int j, List<PrimitiveColorLength> list)
        {
            int ii = i;
            int jj = j;
            int oldValue = -1;
            int curLength = 1;
            string result = "";
            while (ii < dataGrid.Columns.Count && jj >= 0)
            {
                int newValue = Convert.ToInt32(dataGrid[ii, jj].Value);
                if (oldValue == newValue)
                {
                    curLength++;
                    if (curLength < maxPrimitiveLength)
                    {
                        var primitive = new PrimitiveColorLength(oldValue, curLength);
                        list.Add(primitive);
                    }
                    else
                    {
                        curLength = 1;
                        oldValue = newValue;
                    }
                }
                else
                {
                    oldValue = newValue;
                    curLength = 1;
                }
                result += newValue + "  ";
                ii++;
                jj--;
            }
            return result;
        }

        private static void PrintAllPrimitives(List<PrimitiveColorLength> list)
        {
            Console.WriteLine(String.Format("number of primitives: {0}", list.Count));
            foreach (PrimitiveColorLength primitive in list)
            {
                Console.WriteLine(String.Format("color: {0}  length: {1}", primitive.color, primitive.length));
            }
        }

        private static double CountP1(List<PrimitiveColorLength> list, List<int> allColors, List<int> allLengths)
        {
            double result = 0;
            foreach (int color in allColors)
            {
                foreach (int length in allLengths)
                {
                    double count = 0;
                    foreach (PrimitiveColorLength primitive in list)
                    {
                        if (primitive.color == color && primitive.length == length)
                        {
                            count++;
                        }
                    }
                    result += count/Math.Pow(length, 2);
                }
            }
            if (list.Count > 0)
                result /= list.Count;
            return result;
        }

        private static double CountP2(List<PrimitiveColorLength> list, List<int> allColors, List<int> allLengths)
        {
            double result = 0;
            foreach (int color in allColors)
            {
                foreach (int length in allLengths)
                {
                    double count = 0;
                    foreach (PrimitiveColorLength primitive in list)
                    {
                        if (primitive.color == color && primitive.length == length)
                        {
                            count++;
                        }
                    }
                    result += count*Math.Pow(length, 2);
                }
            }
            return result;
        }

        private static double CountP3(List<PrimitiveColorLength> list, List<int> allColors, List<int> allLengths)
        {
            double result = 0;

            foreach (int length in allLengths)
            {
                double count = 0;
                foreach (int color in allColors)
                {
                    foreach (PrimitiveColorLength primitive in list)
                    {
                        if (primitive.color == color && primitive.length == length)
                        {
                            count++;
                        }
                    }
                }
                result += Math.Pow(count, 2);
            }
            if (list.Count > 0)
                result /= list.Count;
            return result;
        }

        private static List<int> GetAllColorsInList(List<PrimitiveColorLength> list)
        {
            var colorList = new List<int>();
            foreach (PrimitiveColorLength primitive in list)
            {
                if (!colorList.Contains(primitive.color))
                {
                    colorList.Add(primitive.color);
                }
            }
            return colorList;
        }

        private static List<int> GetAllLengthsInList(List<PrimitiveColorLength> list)
        {
            var lengthsList = new List<int>();
            foreach (PrimitiveColorLength primitive in list)
            {
                if (!lengthsList.Contains(primitive.length))
                {
                    lengthsList.Add(primitive.length);
                }
            }
            return lengthsList;
        }
    }
}