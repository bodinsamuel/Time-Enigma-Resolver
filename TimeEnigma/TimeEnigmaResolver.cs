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

        private int?[] Sequence { get; set; }

        private int Length { get; set; }

        private int Try { get; set; }

        private int Solved { get; set; }

        private Dictionary<int,Dictionary<int,int>> solvedSeq { get; set; }


        public TimeEnigmaResolver(int?[] _sequence, bool _multiple)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            Dictionary<int, Dictionary<int, int>> l1 = new Dictionary<int, Dictionary<int, int>>();
            solvedSeq = l1;

            Sequence = _sequence;
            Length = _sequence.Length;
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

                if (!_tseq.ContainsKey(toRight))
                {
                    int toPos = Convert.ToInt32(Sequence[toRight]);
                    _tseq.Add(toRight, toPos);
                    if (!resolver(toRight, _tseq))
                        _tseq.Remove(toRight);
                    else
                        return true;
                }

                if (!_tseq.ContainsKey(toLeft))
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
            Console.WriteLine("La séquence était "+ string.Join(",", Sequence));
            if (solvedSeq.Count > 0)
            {
                Console.WriteLine("Résolut en " + Try + " essais");
                if (Multiple)
                {
                    Console.WriteLine(Solved + " solutions trouvées.");
                    Console.WriteLine("Soit, en moyenne, " + Try / Solved + " essais par solution.");
                }
                Console.WriteLine("Temps d'éxecution de " + time.Elapsed.TotalSeconds + " secondes.");

                Console.WriteLine("----------------------------------------------- \n");
                foreach (var s in solvedSeq)
                {
                    Console.WriteLine("Position: " + string.Join(",", s.Value.Keys).Replace(",", " - "));
                    Console.WriteLine("Nombre  : " + string.Join(",", s.Value.Values).Replace(",", " - "));
                    Console.WriteLine("\n");
                }
            }
            else
            {
                Console.WriteLine("Non résolut\n - " + Try + " essais.");
                Console.WriteLine(" - " + time.Elapsed.TotalSeconds + " secondes.");
            }
        }
    }
}
