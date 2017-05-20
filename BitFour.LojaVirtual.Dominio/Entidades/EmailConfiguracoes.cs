namespace BitFour.LojaVirtual.Dominio.Entidades
{
    public class EmailConfiguracoes
    {
        public bool UsarSsl = false;
        public string ServidorSmtp = "smtp.bitfour.com.br";
        public int ServidorPorta = 587;
        public string Usuario = "Glauber";
        public bool EscreverArquivo = false;
        public string PastaDoArquivo = @"c:\envioenail";
        public string Para = "grobis@hotmail.com";
        public string De = "glaubercasttro@gmail.com";
    }
}