using System;
using FindPatientGroups.Models;

namespace FindPatientGroups.Services
{
    public class MatrixServices : IMatrixServices
    {
        private int[,] patientmatrix;

        //just displaying the matrix from request
        public int[,] displayMatrix(MatrixClass matrix)
        {
            patientmatrix = matrix.matrix;
            return patientmatrix;
        }
           
    }
}
