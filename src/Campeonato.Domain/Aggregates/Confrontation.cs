namespace Campeonato.Domain.Aggregates
{
    public class Confrontation
    {
        private readonly List<Match> _matches = new();

        public string PhaseName { get; private set; } = default!;
        public IReadOnlyCollection<Match> Matches => _matches.AsReadOnly();

        public Confrontation()
        { }

        public Confrontation(
            string phaseName,
            IEnumerable<Match> matches
        )
        {
            PhaseName = phaseName;
            _matches = matches.ToList();
        }
    }
}