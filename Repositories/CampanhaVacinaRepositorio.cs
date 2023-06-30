using CampanhaVacinacao.Models;


namespace CampanhaVacinacao.Repositories
{
    public class SolicitanteRepository
    {
        private readonly ApplicationDbContext _context;

        public SolicitanteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Solicitantes GetByCPF(string cpf)
        {
            return _context.Solicitantes.FirstOrDefault(s => s.CPF == cpf);
        }

        public void Add(Solicitantes solicitante)
        {
            _context.Solicitantes.Add(solicitante);
            _context.SaveChanges();
        }
    }

    public class RelatorioRepository
    {
        private readonly ApplicationDbContext _context;

        public RelatorioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Relatorio relatorio)
        {
            _context.Relatorios.Add(relatorio);
            _context.SaveChanges();
        }

        public List<Relatorio> GetAll()
        {
            return _context.Relatorios.ToList();
        }
    }
}
