namespace RecruitmentAPI.Contracts
{
    public record RegisterCandidateRequest
        (
            string Name,
            string FirstName,
            string Patronymic,
            string Email,
            bool TestIsNeeded 
        );
}
