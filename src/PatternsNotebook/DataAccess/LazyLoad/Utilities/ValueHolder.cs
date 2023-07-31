namespace PatternsNotebook.DataAccess.LazyLoad.Utilities;

internal abstract class ValueHolder<T>
{
    private T? _value;

    public virtual T GetValue(object param)
    {
        if (_value == null)
        {
            _value = LoadValue(param);
        }

        return _value;
    }

    protected abstract T LoadValue(object param);
}

internal sealed class GenericValueHolder<T> : ValueHolder<T>
{
    private readonly Func<object, T> _getValue;

    public GenericValueHolder(Func<object, T> getValue)
    {
        _getValue = getValue;
    }
    protected override T LoadValue(object param)
    {
        return _getValue(param);
    }
}