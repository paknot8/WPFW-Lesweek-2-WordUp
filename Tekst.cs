public class Tekst
    {
        public List<Woord> Woorden { get; set; }
        public BestandInfo BestandInfo { get; set; }

        public Tekst(List<Woord> woorden, BestandInfo bestandInfo)
        {
            Woorden = woorden;
            BestandInfo = bestandInfo;
        }

        public List<Woord> GetWoorden()
        {
            return Woorden;
        }

        public void DraaiOm()
        {
            Woorden.Reverse();
        }
    }

    public struct BestandInfo
    {
        public string Pad { get; set; }
        public string FileName { get; set; }
    }