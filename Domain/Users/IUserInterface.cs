﻿namespace Domain.Users;

public interface IUserRepository
{
    Task<List<User>> GetAll();
    Task<User?> GetByIdAsync(UserId id);
    Task<bool> ExistsAsync(UserId id);
    void Add(User user);
    void Update(User user);
    void Delete(User user);
}
