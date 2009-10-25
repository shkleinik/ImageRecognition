using System;
using System.Collections.Generic;
using System.Text;

namespace MPO.BisnessLogic
{
    public class IntersectionsAnalyzer
    {
        public static void InitIntersections(Symbol sym,List<ZondDraw> zonds)
        {
            sym.Intersections = new int[zonds.Count];
            for (int i = 0; i < zonds.Count; i++)
            {
                sym.Intersections[i]= GetNumIntersections(zonds[i].ZondLine,sym.SymbolPoints,sym.Height,sym.Width);
            }
        }

        private static int GetNumIntersections(int[,] zond,int[,] sym,int ySize,int xSize)
        {
            int inters = 0;
            for (int y = 0; y < ySize; y++)
            {
                for (int x = 0; x < xSize; x++)
                {
                    if (zond[y, x] == 1&&zond[y,x]==sym[y,x])
                    {
                        inters++;
                    }
                }
            }
            return inters;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="classes">known classes</param>
        /// <param name="undefined">unknown symbol</param>
        /// <returns>index of class in list which is most similar</returns>
        public static int Analyze(List<Symbol> classes)
        {
            int index = -1;
            int minDiffer = int.MaxValue;
            for (int i = 0; i < classes.Count-1; i++)
            {
                int dif = GetDiffer(classes[i].Intersections, classes[classes.Count-1].Intersections);
                if ( dif< minDiffer)
                {
                    index = i;
                    minDiffer = dif;
                }
            }
            return index;
        }

        private static int GetDiffer(int[] known,int[] undef)
        {
            int differ = 0;
            for (int i = 0; i < known.Length; i++)
            {
                differ+= Math.Abs(known[i] - undef[i]);
            }
            return differ;
        }
    }
}
