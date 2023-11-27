namespace RestaurantReservation.Db.Interfaces;

public interface ICrud<T> where T : class
{
    public void Update(int id, T newData);
    public void Create(T newData);
    public void Delete(int id);
}