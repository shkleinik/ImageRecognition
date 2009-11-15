//-----------------------------------------------------------------------
// <copyright file="KvaziTopologicMethod.cs" company="Walash Ltd.">
//     Copyright (c) Walash Ltd. All rights reserved.
// </copyright>
// <author>Pavel Shkleinik</author>
//-----------------------------------------------------------------------

namespace MPO.BisnessLogic
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Implements kvazitopologic method of letters recognition.
    /// </summary>
    public class KvaziTopologicMethod
    {
        #region Fields
        /// <summary>
        /// Stores initial state of the being recognized image.
        /// </summary>
        private readonly int[,] initialMatrix;

        #endregion

        #region Properties
        /// <summary>
        /// Gets two-dimensional array of int. Each element contains number of neighbours value of which is not equal zero.
        /// </summary>
        public int[,] NeighboursMatrix { get; private set; }

        /// <summary>
        /// Gets two-dimensional array of int. Each element contains number of neighbours value of which is not equal zero.
        /// </summary>
        public int[,] MultipliesMatrix { get; private set; }

        /// <summary>
        /// Gets matrix according the formula: C8ij = A8ij - B8ij.
        /// Where A8 is element of neighbours matrix and B8 is element of multiplies matrix.
        /// </summary>
        public int[,] SwitchesMatrix { get; private set; }

        /// <summary>
        /// Gets an instance of Symbol class. 
        /// </summary>
        public Symbol RecognizedSymbol { get; private set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="KvaziTopologicMethod"/> class.
        /// </summary>
        /// <param name="binarizedMatrix">Array of integers. Should be prepared thined
        /// and binarized(black and white) matrix of the being recognized image.
        /// 1 is treated as black.
        /// 0 is treated as white.
        /// </param>
        public KvaziTopologicMethod(int[,] binarizedMatrix)
        {
            initialMatrix = binarizedMatrix;
            GetNeighboursMatrix();
            GetMultipliesMatrix();
            GetSwitchesMatrix();
            GetPatternKeys();
        }

        /// <summary>
        /// Prevents a default instance of the <see cref="KvaziTopologicMethod"/> class from being created. 
        /// </summary>
        private KvaziTopologicMethod()
        {
        }
        #endregion

        #region Get methods
        /// <summary>
        /// Returns two-dimensional array of int. Each element will contain number of neighbours value of which is not equal zero.
        /// </summary>
        private void GetNeighboursMatrix()
        {
            var height = initialMatrix.GetLength(0);
            var width = initialMatrix.GetLength(1);
            NeighboursMatrix = new int[height, width];

            for (var i = 0; i < height; i++)
            {
                for (var j = 0; j < width; j++)
                {
                    NeighboursMatrix[i, j] = initialMatrix[i, j] == 1 ? GetNeighboursNumber(initialMatrix, i, j) : 0;
                }
            }
        }

        /// <summary>
        /// Returns two-dimensional arary of int. Each cell will contain number consequent "1" pairs.
        /// </summary>
        /// <remarks>
        /// For instance for matrix:
        ///     0 1 1
        ///     0 1 0
        ///     1 1 0
        /// return value should be 2.
        /// Work only for black pixels.
        /// For instance for matrix:
        /// 1 1 1
        /// 1 0 1
        /// 1 1 1
        /// return value shold be 0.
        /// </remarks>
        private void GetMultipliesMatrix()
        {
            var height = initialMatrix.GetLength(0);
            var width = initialMatrix.GetLength(1);
            MultipliesMatrix = new int[height, width];

            for (var i = 0; i < height; i++)
            {
                for (var j = 0; j < width; j++)
                {
                    MultipliesMatrix[i, j] = initialMatrix[i, j] == 1 ? GetMultipliesNumber(initialMatrix, i, j) : 0;
                }
            }
        }

        /// <summary>
        /// Retrns matrix according the formula: C8ij = A8ij - B8ij.
        /// Where A8 is element of neighbours matrix and B8 is element of multiplies matrix.
        /// </summary>
        private void GetSwitchesMatrix()
        {
            var height = initialMatrix.GetLength(0);
            var width = initialMatrix.GetLength(1);
            SwitchesMatrix = new int[height, width];

            for (var i = 0; i < width; i++)
            {
                for (var j = 0; j < height; j++)
                {
                    SwitchesMatrix[i, j] = NeighboursMatrix[i, j] - MultipliesMatrix[i, j];
                }
            }
        }

        /// <summary>
        /// Returns keys for current pattern.
        /// </summary>
        public void GetPatternKeys()
        {
            RecognizedSymbol = new Symbol { Keys = new List<int>() };

            for (var i = 0; i < SwitchesMatrix.GetLength(0); i++)
            {
                for (var j = 0; j < SwitchesMatrix.GetLength(1); j++)
                {
                    if (SwitchesMatrix[i, j] == 1 || SwitchesMatrix[i, j] >= 3)
                        RecognizedSymbol.Keys.Add(SwitchesMatrix[i, j]);
                }
            }
        }
        #endregion

        #region Auxiliary methods
        /// <summary>
        /// Returns number of neighbours of current pixel.
        /// </summary>
        /// <param name="sourceMatrix">Matrix of pixels. Matrix should be binarized (contain only "0" or "1").</param>
        /// <param name="currI">X-coordinate of pixel number of neighbours would be returned.</param>
        /// <param name="currJ">Y-coordinate of pixel number of neighbours would be returned.</param>
        /// <returns>Returns number of neighbours of current pixel.</returns>
        private static int GetNeighboursNumber(int[,] sourceMatrix, int currI, int currJ)
        {
            var neighboursNumber = 0;
            for (var i = currI - 1; i <= currI + 1; i++)
            {
                for (var j = currJ - 1; j <= currJ + 1; j++)
                {
                    if (i < 0 || j < 0 || i > (sourceMatrix.GetLength(0) - 2) || j > (sourceMatrix.GetLength(1) - 2))
                        continue;
                    if (i == currI && j == currJ)
                        continue;

                    neighboursNumber += sourceMatrix[i, j];
                }
            }

            return neighboursNumber;
        }

        /// <summary>
        /// Returns an int value whick specifies how many consequent "1" pairs surrounds current pixel.
        /// </summary>
        /// <remarks>
        ///  Following matrix specifies the direction of movement during the rounding.
        ///  1 2 3
        ///  8 0 4
        ///  7 6 5
        /// </remarks>
        /// <param name="sourceMatrix">Matrix containing pixel being investigated.</param>
        /// <param name="currI">X-position of pixel being investigated.</param>
        /// <param name="currJ">Y-position pixel being investigated.</param>
        /// <returns>Returns an int value whick specifies how many consequent "1" pairs surrounds current pixel.</returns>
        private static int GetMultipliesNumber(int[,] sourceMatrix, int currI, int currJ)
        {
            var neighboursMultiplies = 0;
            try
            {
                neighboursMultiplies += sourceMatrix[currI - 1, currJ - 1] * sourceMatrix[currI, currJ - 1];
                neighboursMultiplies += sourceMatrix[currI, currJ - 1] * sourceMatrix[currI + 1, currJ - 1];
                neighboursMultiplies += sourceMatrix[currI + 1, currJ - 1] * sourceMatrix[currI + 1, currJ];
                neighboursMultiplies += sourceMatrix[currI + 1, currJ] * sourceMatrix[currI + 1, currJ + 1];
                neighboursMultiplies += sourceMatrix[currI + 1, currJ + 1] * sourceMatrix[currI, currJ + 1];
                neighboursMultiplies += sourceMatrix[currI, currJ + 1] * sourceMatrix[currI - 1, currJ + 1];
                neighboursMultiplies += sourceMatrix[currI - 1, currJ + 1] * sourceMatrix[currI - 1, currJ];
                neighboursMultiplies += sourceMatrix[currI - 1, currJ] * sourceMatrix[currI - 1, currJ - 1];
            }
            catch (IndexOutOfRangeException)
            {
                return 0;
            }

            return neighboursMultiplies;
        }
        #endregion
    }
}

///// <summary>
///// Stores initial state of the being recognized image.
///// </summary>
//private readonly int[,] initialMatrix;

///// <summary>
///// Stores two-dimensional array of int. Each element contains number of neighbours value of which is not equal zero.
///// </summary>
//private int[,] neighboursMatrix;

///// <summary>
///// Stores two-dimensional array of int. Each element contains number of consequent "1" pairs.
///// </summary>