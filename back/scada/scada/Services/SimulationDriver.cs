namespace scada.Services
{
    // Ovo je samo primer proste implementacije simulacionog driver-a sa vrednostima signala koje se krecu od 0 do 100
    // Ukoliko u sistemu postoji i RealTime driver, preporuka je da se koristi nasledjivanje ili implementacija interfejsa, zarad uniformnog pristupa ovim driver-ima
    public static class SimulationDriver
    {
        public static float ReturnValue(string address)
        {
            // U ovoj implementaciji simulacionog driver-a adrese su opisne (po uzoru na iFIX)
            // S - sine
            // C - cosine
            // R - ramp
            if (address == "S") return (float)Sine();
            else if (address == "C") return (float)Cosine();
            else if (address == "R") return (float)Ramp();
            else return -1000;
        }

        private static double Sine()
        {
            return 100 * Math.Sin((double)DateTime.Now.Second / 60 * Math.PI);
        }

        private static double Cosine()
        {
            return 100 * Math.Cos((double)DateTime.Now.Second / 60 * Math.PI);
        }

        private static double Ramp()
        {
            return 100 * DateTime.Now.Second / 60;
        }
    }
}
