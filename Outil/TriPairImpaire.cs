namespace Outil
{
    public static class TriPairImpaire
    {
        // utilisation du Tri Pair/Impaire
        public static int[] TriDesc(int[] tabInt)
        {
            bool sortie = false;

            while (!sortie)
            {
                sortie = true;
                for (int i = 0; i < tabInt.Length - 1; i += 2)
                {
                    if (tabInt[i] < tabInt[i + 1])
                    {
                        (tabInt[i + 1], tabInt[i]) = (tabInt[i], tabInt[i + 1]); //type tuple
                        sortie = false;
                    }
                }

                for (int i = 1; i < tabInt.Length - 1; i += 2)
                {
                    if (tabInt[i] < tabInt[i + 1])
                    {
                        (tabInt[i + 1], tabInt[i]) = (tabInt[i], tabInt[i + 1]); //type tuple
                        sortie = false;
                    }
                }
            }
            return tabInt;
        }

        public static int[] TriAsc(int[] tabInt)
        {
            bool sortie = false;

            while (!sortie)
            {
                sortie = true;
                for (int i = 0; i < tabInt.Length - 1; i += 2)
                {
                    if (tabInt[i] > tabInt[i + 1])
                    {
                        (tabInt[i + 1], tabInt[i]) = (tabInt[i], tabInt[i + 1]); //type tuple
                        sortie = false;
                    }
                }

                for (int i = 1; i < tabInt.Length - 1; i += 2)
                {
                    if (tabInt[i] > tabInt[i + 1])
                    {
                        (tabInt[i + 1], tabInt[i]) = (tabInt[i], tabInt[i + 1]); //type tuple
                        sortie = false;
                    }
                }
            }
            return tabInt;
        }
    }
}