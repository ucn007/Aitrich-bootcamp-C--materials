using Exercise.Models;

namespace Exercise.Interface;

public interface IJobinterface
{
    void Add(Job job);
    List<Job> GetAll();
    Job GetById(int id);
    void Delete(int id);
}