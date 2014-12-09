using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace climber_problem
{
    class Program
    {

        static void Main(string[] args)
        {
            Solver mySolver = new Solver();
            mySolver.run();
            Console.ReadLine();
        }

        class Solver
        {
            List<Tuple<int, int, int>> _tuples = new List<Tuple<int, int, int>>();
            public void run()
            {
                getInput();
                Console.WriteLine(solve(_tuples));
            }

            public int solve(List<Tuple<int, int, int>> tuples)
            {
                int ret = 0;

                //figure out total X distance to walk:
                int biggestEndX = 0;
                foreach (var tup in tuples)
                {
                    if (tup.Item2 > biggestEndX)
                        biggestEndX = tup.Item2;
                }
                ret += biggestEndX;

                //figure out total Y distance to walk:
                //foreach tuple..

                var ctuples = getContiguousTuples(tuples);
                foreach (var ctuple in ctuples)
                {
                    ret += 2*ctuple.Item3;
                }

                return ret;
            }


            private List<Tuple<int, int, int>> getContiguousTuples(List<Tuple<int, int, int>> tuples)
            {
                List<Tuple<int, int, int>> ret = new List<Tuple<int, int, int>>();
                List<Tuple<int, int, int>> processedTuples = new List<Tuple<int, int, int>>();
                foreach (var tup in tuples)
                {
                    if (!processedTuples.Contains(tup))
                    {
                        var tupStart = tup.Item1;
                        var tupEnd = tup.Item2;
                        var tupHeight = tup.Item3;
                        foreach (var tup2 in tuples)
                        {
                            var tup2Start = tup2.Item1;
                            var tup2End = tup2.Item2;
                            var tup2Height = tup2.Item3;
                            if ((tup2Start >= tupStart && tup2Start <= tupEnd) ||
                                (tup2End >= tupStart && tup2End <= tupEnd))
                            {
                                if (tup2Start < tupStart)
                                    tupStart = tup2Start;
                                if (tup2End > tupEnd)
                                    tupEnd = tup2End;
                                if (tup2Height > tupHeight)
                                    tupHeight = tup2Height;

                                processedTuples.Add(tup2);
                            }
                        }

                        ret.Add(new Tuple<int, int, int>(tupStart, tupEnd, tupHeight));
                    }
                }
                return ret.Distinct().ToList();
            }

            private void getInput()
            {
                int numberRectangles = 0;

                Console.WriteLine("Enter number of rectangles:");
                if (!int.TryParse(Console.ReadLine(), out numberRectangles))
                    inputError();

                for (int i = 1; i <= numberRectangles; i++)
                {
                    Console.WriteLine("Enter 3-tuple #" + i.ToString());
                    _tuples.Add(parseTuple(Console.ReadLine()));
                }
            }

            private Tuple<int, int, int> parseTuple(string input)
            {
                var inputs = input.Split(',');
                if (inputs.Length != 3)
                    inputError();
                List<int> ints = new List<int>();
                foreach (var s in inputs)
                {
                    var i = 0;
                    if (!int.TryParse(s, out i))
                        inputError();

                    ints.Add(i);
                }

                return new Tuple<int, int, int>(ints[0], ints[1], ints[2]);
            }


            private void inputError()
            {
                Console.WriteLine("Invalid input");
                getInput();
            }
        }
    }
}
