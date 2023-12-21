var query = from rr in result
            join rr2Grouped in (
                from rr2 in result
                where rr2.WireAmount != null
                group rr2 by rr2.SequenceId into rr2Group
                select new
                {
                    SequenceId = rr2Group.Key,
                    SourceRef = string.Join(", ", rr2Group.Select(rr3 => rr3.SourceRef).DefaultIfEmpty())
                }
            ) on rr.SequenceId equals rr2Grouped.SequenceId
            where rr.SourceRef == null
            select new
            {
                rr.SequenceId,
                SourceRef = rr2Grouped.SourceRef.Length > 50 ? rr2Grouped.SourceRef.Substring(0, 50) : rr2Grouped.SourceRef
            };

foreach (var item in query)
{
    // Perform the update using item.SequenceId and item.SourceRef
    // Update logic here...
}
