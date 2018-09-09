using System;



namespace ClssVmMdl.Validacion
{
    public  class ValTam
    {
        
        public string LimitStrg(string val, int tam)
        {
            if (string.IsNullOrEmpty(val))
                return "";
            if (val.Length > tam)
                val = val.Substring(0, tam);
            return val;
        }

        public bool LimitDec(double val, int ent,int dec)
        {
            double num;
            num = Math.Pow(10, ent);
            val = Math.Round(val, dec);
            if (val > num)
             return  false;
            return true;
        }

        public double LimitDec( int ent, int dec)
        {
            double num;
            num = Math.Pow(10, ent);
            return num - 1;
        }

        public double ValDec(string val)
        {
            return 4;
        }

    }
}
