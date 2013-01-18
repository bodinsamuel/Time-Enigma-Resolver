using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace TimeEnigma
{
    public class TimeEnigmaResolver
    {
        public bool Multiple { get; set; }

        private List<int> Sequence { get; set; }

        private int Length { get; set; }

        private int Try { get; set; }

        private int Solved { get; set; }

        private Dictionary<int,Dictionary<int,int>> solvedSeq { get; set; }


        /**
        * @params int?[] The sequence
        * @params bool True for multiple solution, false for the first found
        **/
        public TimeEnigmaResolver(List<int> _sequence, bool _multiple)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            Dictionary<int, Dictionary<int, int>> l1 = new Dictionary<int, Dictionary<int, int>>();
            solvedSeq = l1;

            Sequence = _sequence;
            Length = _sequence.Count;
            Multiple = _multiple;

            for (int i = 0; i < Length; i++)
            {
                Dictionary<int, int> temp = new Dictionary<int, int>();
                temp.Add(i, Convert.ToInt32(Sequence[i]));
                var test = resolver(i, temp);
                if (test == true && !Multiple)
                    break;
                else if (test == true && Multiple)
                {
                    Solved++;
                }
            }

            sw.Stop();
            display(sw);
        }

        private bool resolver(int _case, Dictionary<int, int> _tseq)
        {
            if (Length > _tseq.Count)
            {
                Try++;
                int pos = Convert.ToInt32(Sequence[_case]);
                int toRight = (pos + _case) < Length ? (pos + _case) : (pos + _case) - Length;
                int toLeft = (_case - pos) >= 0 ? (_case - pos) : Length - (pos - _case);

                if (!_tseq.ContainsKey(toRight) && toRight >= 0 && toRight < Length)
                {
                    int toPos = Convert.ToInt32(Sequence[toRight]);
                    _tseq.Add(toRight, toPos);
                    if (!resolver(toRight, _tseq))
                        _tseq.Remove(toRight);
                    else
                        return true;
                }

                if (!_tseq.ContainsKey(toLeft) && toLeft >= 0 && toLeft < Length)
                {
                    int toPos = Convert.ToInt32(Sequence[toLeft]);
                    _tseq.Add(toLeft, toPos);
                    var rec = resolver(toLeft, _tseq);
                    if (!rec)
                        _tseq.Remove(toLeft);
                    else
                        return true;
                }
                return false;
            }
            else
            {
                output(_tseq);
                return true;
            }
        }

        private bool output(Dictionary<int,int> output)
        {
            solvedSeq.Add(solvedSeq.Count, output);
            return true;
        }

        private void display(Stopwatch time)
        {
            Console.WriteLine("----------------------- START ------------------------");
            Console.WriteLine("The sequence was "+ string.Join(",", Sequence));
            if (solvedSeq.Count > 0)
            {
                Console.WriteLine("Solved in " + Try + " trials");
                if (Multiple)
                {
                    Console.WriteLine(Solved + " solutions found");
                    Console.WriteLine("Is, on average, " + Try / Solved + " trials per solution");
                }
                Console.WriteLine("Executed in " + time.Elapsed.TotalSeconds + " seconds");

                Console.WriteLine("----------------------------------------------- \n");
                foreach (var s in solvedSeq)
                {
                    Console.WriteLine("Pos: " + string.Join(",", s.Value.Keys).Replace(",", " - "));
                    Console.WriteLine("Num: " + string.Join(",", s.Value.Values).Replace(",", " - "));
                }
            }
            else
            {
                Console.WriteLine("Unsolved\n - " + Try + " trials.");
                Console.WriteLine(" - " + time.Elapsed.TotalSeconds + " seconds.");
            }
            Console.WriteLine("----------------------- END ------------------------\n\n");
        }
    }
}
