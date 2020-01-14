using System;
using FindPatientGroups.Models;

namespace FindPatientGroups.Services
{
    public interface IMatrixServices
    {
        int[,] displayMatrix(MatrixClass matrix);
    }
}
