namespace MPO.BisnessLogic
{
    using System.Collections.Generic;

    public class ZongeSun
    {
        static int blackValue = 1;
        static int whiteValue = 0;

        public static int BlackValue
        {
            get { return blackValue; }
            set
            {
                blackValue = (value % 2); whiteValue = ((value + 1) % 2);
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
            for (var times = 0; times < 2; times++)
                for (var y = 0; y < ySize; y++)
                {
                    for (var x = 0; x < xSize; x++)
                    {
                        var littleMas = GetValuesFromNeighbourCells(matrixToChange, y, x, xSize, ySize);
                        if (!StaticPart(littleMas, y, x, xSize, ySize))
                            continue;

                        if (times == 0)
                            if (Algorithm1(littleMas, y, x, xSize, ySize))
                            {
                                matrixToChange[y, x] = whiteValue;
                            }
                        if (times == 1)
                            if (Algorithm2(littleMas, y, x, xSize, ySize))
                            {
                                matrixToChange[y, x] = whiteValue;
                            }
                    }
                }
        }

        private static bool StaticPart(List<int[]> littleMas, int y, int x, int xSize, int ySize)
        {
            int sum = GetNeighbourCellsSum(littleMas, y, x, xSize, ySize);
            if (sum >= 2 || sum <= 6)
            {
                if (GetNumPerehodov(littleMas, y, x, xSize, ySize) == 1)
                {
                    return true;
                }
            }
            return false;
        }

        private static bool Algorithm1(List<int[]> littleMas, int y, int x, int xSize, int ySize)
        {
            //p2*p4*p6
            if (littleMas[1][2] * littleMas[3][2] * littleMas[5][2] == 0)
            {
                //p4*p6*p8
                if (littleMas[3][2] * littleMas[5][2] * littleMas[7][2] == 0)
                {
                    return true;
                }
            }
            return false;
        }

        private static bool Algorithm2(List<int[]> littleMas, int y, int x, int xSize, int ySize)
        {
            //p2*p4*p8
            if (littleMas[1][2] * littleMas[3][2] * littleMas[7][2] == 0)
            {
                //p2*p6*p8
                if (littleMas[1][2] * littleMas[5][2] * littleMas[7][2] == 0)
                {
                    return true;
                }
            }
            return false;
        }

        private static int GetNeighbourCellsSum(List<int[]> littleMas, int y, int x, int xSize, int ySize)
        {
            int sum = 0;
            for (int i = 1; i < littleMas.Count; i++)
            {
                if (littleMas[i][2] == blackValue)
                {
                    sum += 1;
                }
            }
            return sum;
        }

        private static int GetNumPerehodov(List<int[]> littleMas, int y, int x, int xSize, int ySize)
        {
            int numPer = 0;
            //проверяем переходы с 3ей клетки
            //данная реализация не замыкает проверку переходов
            //т.е не проверятся переход между 2 и 9 клеткой
            for (int i = 2; i < littleMas.Count; i++)
            {
                if (littleMas[i - 1][2] == whiteValue && littleMas[i][2] == blackValue)
                    numPer++;
            }
            if (littleMas[8][2] == whiteValue && littleMas[1][2] == blackValue)
                numPer++;

            return numPer;
        }

        private static int[] CheckBounds(int[,] mas, int y, int x, int xSize, int ySize)
        {
            if (y < 0 || y >= ySize)
            {
                return (new int[] { -1, -1, 0 });
            }
            if (x < 0 || x >= xSize)
            {
                return (new int[] { -1, -1, 0 });
            }
            return (new int[] { x, y, mas[y, x] });
        }


        //8 1 2
        //7 0 3
        //6 5 4
        private static List<int[]> GetValuesFromNeighbourCells(int[,] mas, int y, int x, int xSize, int ySize)
        {
            List<int[]> littleMas = new List<int[]>();
            //0=x_index,1=y_index, 2=value
            //1,2,3...and so on
            littleMas.Add(CheckBounds(mas, y, x, xSize, ySize));
            littleMas.Add(CheckBounds(mas, y - 1, x, xSize, ySize));
            littleMas.Add(CheckBounds(mas, y - 1, x + 1, xSize, ySize));
            littleMas.Add(CheckBounds(mas, y, x + 1, xSize, ySize));
            littleMas.Add(CheckBounds(mas, y + 1, x + 1, xSize, ySize));
            littleMas.Add(CheckBounds(mas, y + 1, x, xSize, ySize));
            littleMas.Add(CheckBounds(mas, y + 1, x - 1, xSize, ySize));
            littleMas.Add(CheckBounds(mas, y, x - 1, xSize, ySize));
            littleMas.Add(CheckBounds(mas, y - 1, x - 1, xSize, ySize));

            return littleMas;
        }

    }
}
