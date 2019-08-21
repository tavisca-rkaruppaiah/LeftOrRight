using System;
using System.Collections.Generic;

namespace LeftOrRight
{
    public class ValidateProgram
    {
        public int FindMaximumDistance(int maximuDistatnce, int _maximumDistance)
        {
            return _maximumDistance = _maximumDistance > maximuDistatnce ? _maximumDistance : maximuDistatnce;
        }

        public bool IsNegativeNumber(int distanceCover)
        {
            return distanceCover > 0;
        }

        public bool IsProgramContainInvalidCommand(string program)
        {
            return program.Contains("?");
        }

        public string ChangeInvalidCommandToLeft(string program)
        {
            return program.Replace("?", "L");
        }

        public string ChangeInvalidCommandToRight(string prgram)
        {
            return prgram.Replace("?", "R");
        }
    }
    class LeftOrRight
    {
        private ValidateProgram _validateProgram = new ValidateProgram();
        public int MaxDistance(string program)
        {
            if(!_validateProgram.IsProgramContainInvalidCommand(program))
            {
                return FindMaximumDistanceCovered(program);
            }
            else
            {
                int _leftCommand = FindMaximumDistanceCovered(_validateProgram.ChangeInvalidCommandToLeft(program));
                int _rightCommand = FindMaximumDistanceCovered(_validateProgram.ChangeInvalidCommandToRight(program));
                return _leftCommand > _rightCommand ? _leftCommand : _rightCommand;
            }
        }

        public int FindMaximumDistanceCovered(string program)
        {
            int _distanceCover = 0;
            List<int> _maximumDistance = new List<int>();

            foreach (var command in program)
            {
                if (command == 'L')
                {
                    _distanceCover--;
                }
                else if (command == 'R')
                {
                    _distanceCover++;
                }
                if (_validateProgram.IsNegativeNumber(_distanceCover))
                {
                    _maximumDistance.Add(_distanceCover);
                }
                else
                {
                    _maximumDistance.Add(_distanceCover*-1);
                }

            }
            _maximumDistance.Sort();
            return _maximumDistance[_maximumDistance.Count-1];
        }

        

        #region Testing code Do not change
        public static void Main(String[] args)
        {
            LeftOrRight leftOrRight = new LeftOrRight();
            String input = Console.ReadLine();
            do
            {
                Console.WriteLine(leftOrRight.MaxDistance(input));
                input = Console.ReadLine();
            } while (input != "-1");
        }
        #endregion
    }
}
