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
        private static int[] directions = { -1, 0, 1 };

        //function to find number of groups
        public int numberOfGroups(MatrixClass matrix)
        {
            patientmatrix = matrix.matrix;
            int numberOfGroups = 0;

            bool[,] cellsVisited = new bool[patientmatrix.GetLength(0), patientmatrix.GetLength(1)];

            for(int i = 0; i < patientmatrix.GetLength(0); i++)
            {
                for(int j = 0; j < patientmatrix.GetLength(1); j++)
                {
                    if(patientmatrix[i,j]==1 && cellsVisited[i, j] != true)
                    {
                        numberOfGroups++;

                        //Call function to perform Depth First Search on the element
                        //Pass the matrix, row index, column index and cellsVisited matrix to traverse all the neighbours

                        DepthFirstSearch(patientmatrix, i, j, cellsVisited);
                    }
                    else if(!(patientmatrix[i,j]==1 || patientmatrix[i, j] == 0))
                    {
                        return -1;
                    } 
                }
            }

            return numberOfGroups;
        }

        static void DepthFirstSearch(int[,] arr , int i, int j, bool[,] arrVisited)
        {
            //check if element is already visited
            if (arrVisited[i, j])
            {
                return;
            }

            //mark the element visited as true
            arrVisited[i, j] = true;

            //all the sorrounding elements must be checked

            //the direction to check the neighbours
            int rowDirection, colDirection;

            for(int k=0; k< directions.Length; k++)
            {
                //fix the row
                rowDirection = directions[k];
                for(int l=0; l < directions.Length; l++)
                {
                    //change column for each row to cover all neighbour elements
                    colDirection = directions[l];

                    //skip if the element is current element
                    if (rowDirection == 0 && colDirection == 0)
                    {
                        continue;
                    }

                    //now the neighbour must be checked if sick or not
                    if (checkNeighbour(arr, i + rowDirection, j + colDirection))
                    {
                        DepthFirstSearch(arr, i + rowDirection, j + colDirection, arrVisited);
                    }

                }
            }


        }

        static bool checkNeighbour(int [,] arr, int m, int n)
        {
            //check if the row index and col index are within the limits
            if((m>=0) && (m < arr.GetLength(0)) && (n>=0) && (n < arr.GetLength(1)))
            {
                //check if neighbour is sick
                if (arr[m, n] == 1)
                {
                    return true;
                }
            }
            return false;
        }


    }
}
