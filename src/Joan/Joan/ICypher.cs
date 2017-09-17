namespace Joan
{
    public interface ICypher
    {
        string Run(string input);

        bool SolutionPossible(string input);

        bool ShouldReRunSolution { get; }

        bool NeedsOriginalInput { get; }
    }
}
