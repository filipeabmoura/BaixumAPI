namespace BaixumAPI
{
    public class Artigo
    {
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public string? Conteudo { get; set; }
        public string? Autor { get; set; }
        public string? Tema { get; set; }
        public int FkIdAutor { get; set; }
    }
}
