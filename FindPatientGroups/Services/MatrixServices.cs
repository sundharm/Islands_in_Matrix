using System;
using FindPatientGroups.Models;

/*
    Algorithm :

    Given that, every element in the matrix is a patient, the 0s are normal patients and 1s are sick patients.

    To find group of sick patients every neighbour of the patient must be visited. This can be seen as follows:


    *   *   *
                    
    *   X   *       -> X is the patient and all the *'s are the neighbours. 
    
    *   *   *

    Each neighbour must be checked and we must remember the visited neighbours so that we don't count them twice.

    Checking all the neighbours which are 1 can be done by doing a Depth First Search(DFS) from each element.

    A second matrix is used to keep track if an element is already visited or not.
 
 
 */

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

        //function to find number of groups
        public int numberOfGroups(MatrixClass matrix)
        {
            patientmatrix = matrix.matrix;
            int numberOfGroups = 0;

            bool[,] cellsVisited = new bool[patientmatrix.GetLength(0), patientmatrix.GetLength(1)];

            for(int i = 0; i < patientmatrix.GetLength(0); i++)
            {
                for(int j=0; j < patientmatrix.GetLength(1); j++)
                {
                    if(patientmatrix[i,j]==1 && cellsVisited[i, j] != true)
                    {
                        numberOfGroups++;

                        //Call function to perform Depth First Search on the element
                        //Pass the matrix, row index, column index and cellsVisited matrix to traverse all the neighbours

                        //DepthFirstSearch(patientmatrix, i, j, cellsVisited);
                    }
                }
            }

            return numberOfGroups;
        }
           
    }
}
