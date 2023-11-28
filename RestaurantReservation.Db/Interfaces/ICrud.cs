namespace RestaurantReservation.Db.Interfaces;

public interface ICrud<T> where T : class
{
    public Task UpdateAsync(int id, T newData);
    public Task CreateAsync(T newData);
    public Task DeleteAsync(int id);
}