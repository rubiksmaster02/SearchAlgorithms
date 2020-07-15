﻿using System.Collections.Generic;

namespace SearchAlgorithms.Algorithms
{
    public class Rubikmaster02 : ISearchAlgorithm
    {
        public List<int> MultiSearch<T>(IReadOnlyList<T> input, IReadOnlyList<T> match, int start, int count)
        {
            List<int> matchLocations = new List<int>();
            int       inputLength    = count > input.Count - 1 ? input.Count - 1 : count;
            int       matchLength    = match.Count - 1;

            for (int i = start; i < inputLength; i++)
            {
                if (i + matchLength > inputLength)
                {
                    break;
                }

                if (!input[i].Equals(match[0]) || !input[i + matchLength].Equals(match[matchLength]))
                {
                    continue;
                }

                bool naturalExit = true;
                for (int k = 0; k < matchLength - 1; k++)
                {
                    if (!input[k + i + 1].Equals(match[k + 1]))
                    {
                        naturalExit = false;
                        break;
                    }
                }

                if (naturalExit)
                {
                    matchLocations.Add(i);
                }
                else
                {
                    i += matchLength;
                }
            }

            if (matchLocations.Count > 0)
            {
                return matchLocations;
            }

            matchLocations.Add(-1);
            return matchLocations;
        }

        public int SingleSearch<T>(IReadOnlyList<T> input, IReadOnlyList<T> match, int start, int count)
        {
            int inputLength = count > input.Count - 1 ? input.Count - 1 : count;
            int matchLength = match.Count - 1;

            for (int i = start; i < inputLength; i++)
            {
                if (i + matchLength > inputLength)
                {
                    break;
                }

                if (!input[i].Equals(match[0]) || !input[i + matchLength].Equals(match[matchLength]))
                {
                    continue;
                }

                int k = 0;
                for (; k < matchLength - 1; k++)
                {
                    if (!input[k + i + 1].Equals(match[k + 1]))
                    {
                        break;
                    }
                }

                if (k == matchLength - 1)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}