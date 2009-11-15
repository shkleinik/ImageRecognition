namespace MPO.BisnessLogic
{
    using System.Collections.Generic;

    public class ZongeSyn
    {
        static int blackValue;
        static int whiteValue;

        public ZongeSyn()
        {
            blackValue = 1;
            whiteValue = 0;
        }

        public static int BlackValue
        {
            get { return blackValue; }
            set
            {
                blackValue = (value % 2);
                whiteValue = ((value + 1) % 2);
            }
        }

        /// <summary>
        /// The entry point of Zonge Sun algorithm.
        /// </summary>
        /// <param name="matrixToChange">Matrix with 0 or 1 values.</param>
        /// <param name="xSize">Matrix width.</param>
        /// <param name="ySize">Matrix height.</param>
        public static void Thin(ref int[,] matrixToChange, int xSize, int ySize)
        {
            var tempArray1 = new int[matrixToChange.GetLength(0), matrixToChange.GetLength(1)];
            var finish = false;

            while (!finish)
            {
                finish = true;
                DuplicateArray(matrixToChange, tempArray1);
                for (var times = 1; times <= 2; times++)
                {
                    for (var y = 0; y < ySize; y++)
                    {
                        for (var x = 0; x < xSize; x++)
                        {
                            List<int> littleMas;
                            switch (times)
                            {
                                case 1:
                                    if (matrixToChange[y, x] == whiteValue)
                                        continue;

                                    littleMas = GetValuesFromNeighbourCells(matrixToChange, y, x);

                                    if (!StaticPart(littleMas))
                                        continue;

                                    if (Algorithm1(littleMas))
                                    {
                                        tempArray1[y, x] = whiteValue;
                                        finish = false;
                                    }
                                    break;
                                case 2:
                                    if (tempArray1[y, x] == whiteValue)
                                        continue;

                                    littleMas = GetValuesFromNeighbourCells(matrixToChange, y, x);

                                    if (!StaticPart(littleMas))
                                        continue;

                                    if (Algorithm2(littleMas))
                                    {
                                        tempArray1[y, x] = whiteValue;
                                        finish = false;
                                    }
                                    break;

                                default:
                                    break;
                            }
                        }
                    }
                    DuplicateArray(tempArray1, matrixToChange);
                }
                DuplicateArray(tempArray1, matrixToChange);
            }
        }

        private static void DuplicateArray(int[,] source, int[,] target)
        {
            for (var i = 0; i < source.GetLength(0); i++)
            {
                for (var j = 0; j < source.GetLength(1); j++)
                {
                    target[i, j] = source[i, j];
                }
            }
        }

        private static bool StaticPart(IList<int> littleMas)
        {
            var sum = GetNeighbourCellsSum(littleMas);

            if (sum >= 2 && sum <= 6)
                return GetNumPerehodov(littleMas) == 1;

            return false;
        }

        private static bool Algorithm1(IList<int> littleMas)
        {
            // P2 * P4 * P6
            if (littleMas[1] * littleMas[3] * littleMas[5] == 0)
            {
                // P4 * P6 * P8
                if (littleMas[3] * littleMas[5] * littleMas[7] == 0)
                {
                    return true;
                }
            }
            return false;
        }

        private static bool Algorithm2(IList<int> littleMas)
        {
            // P2 * P4 * P8
            if (littleMas[1] * littleMas[3] * littleMas[7] == 0)
            {
                // P2 * P6 * P8
                if (littleMas[1] * littleMas[5] * littleMas[7] == 0)
                {
                    return true;
                }
            }
            return false;
        }

        private static int GetNeighbourCellsSum(IList<int> littleMas)
        {
            var sum = 0;

            for (var i = 1; i < littleMas.Count; i++)
            {
                if (littleMas[i] == blackValue)
                {
                    sum += 1;
                }
            }
            return sum;
        }

        private static int GetNumPerehodov(IList<int> littleMas)
        {
            var numPer = 0;

            // P2 = 0 && P3 = 1, P3 = 0 && P4 = 1 . . .  P8 = 0 * P9 = 1
            for (var i = 1; i < littleMas.Count - 1; i++)
            {
                if (littleMas[i] == whiteValue && littleMas[i + 1] == blackValue)
                    numPer++;
            }

            // P9 = 0 * P2 = 1
            if (littleMas[8] == whiteValue && littleMas[1] == blackValue)
                numPer++;

            return numPer;
        }

        private static int CheckBounds(int[,] mas, int y, int x)
        {
            var xSize = mas.GetLength(0);
            var ySize = mas.GetLength(1);

            if (y < 0 || y >= ySize || x < 0 || x >= xSize)
                return 0;

            return mas[y, x];
        }

        // P9 P2 P3    8 1 2
        // P8 P1 P4    7 0 3
        // P7 P6 P5    6 5 4
        private static List<int> GetValuesFromNeighbourCells(int[,] mas, int y, int x)
        {
            var littleMas = new List<int>
                                {
                                    CheckBounds(mas, y, x),             // P1
                                    CheckBounds(mas, y - 1, x),         // P2
                                    CheckBounds(mas, y - 1, x + 1),     // P3
                                    CheckBounds(mas, y, x + 1),         // P4
                                    CheckBounds(mas, y + 1, x + 1),     // P5
                                    CheckBounds(mas, y + 1, x),         // P6
                                    CheckBounds(mas, y + 1, x - 1),     // P7
                                    CheckBounds(mas, y, x - 1),         // P8
                                    CheckBounds(mas, y - 1, x - 1)      // P9
                                };
            return littleMas;
        }

    }
}