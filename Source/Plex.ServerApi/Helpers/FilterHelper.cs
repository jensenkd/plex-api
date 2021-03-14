namespace Plex.ServerApi.Helpers
{
    using System.Collections.Generic;
    using System.Linq;

    public static class FilterHelper
    {
        // OPERATORS = {
        //     'iexact': lambda v, q: v.lower() == q.lower(),
        //     'contains': lambda v, q: q in v,
        //     'icontains': lambda v, q: q.lower() in v.lower(),
        //     'ne': lambda v, q: v != q,
        //     'in': lambda v, q: v in q,
        //     'gt': lambda v, q: v > q,
        //     'gte': lambda v, q: v >= q,
        //     'lt': lambda v, q: v < q,
        //     'lte': lambda v, q: v <= q,
        //     'startswith': lambda v, q: v.startswith(q),
        //     'istartswith': lambda v, q: v.lower().startswith(q),
        //     'endswith': lambda v, q: v.endswith(q),
        //     'iendswith': lambda v, q: v.lower().endswith(q),
        //     'exists': lambda v, q: v is not None if q else v is None,
        //     'regex': lambda v, q: re.match(q, v),
        //     'iregex': lambda v, q: re.match(q, v, flags=re.IGNORECASE),

        public static Dictionary<string, string> GetFilterParams(string operation, List<string> values)
        {
            var parameters = new Dictionary<string, string>();

            if (string.IsNullOrEmpty(operation))
            {
                return parameters;
            }

            if (values == null || !values.Any())
            {
                return parameters;
            }

            switch (operation.ToLower())
            {
                case "exact":
                    parameters.Add("=", "=" + string.Join(",", values));
                    break;
                case "contains":
                    parameters.Add("=", string.Join(",", values));
                    break;
            }

            return parameters;
        }

    }
}
