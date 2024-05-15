SELECT '[' + (
    select concat('{',
    '"ID":',ID,',',
    '"ContainerID":',[ContainerID],',',    
    '"StartDate":','"',CONVERT(varchar, StartDate, 104),'"',',',
    '"EndDate":','"',CONVERT(varchar, EndDate, 104),'"',',',
    '"OperationType":','"',OperationType,'"',',',
    '"OperatorName":','"',OperatorName,'"',',',
    '"InspectionLocation":','"',InspectionLocation,'"',
    '},')
    as [data()]
    from Operations
    where ContainerID = ContainerID
    for xml PATH('') 
) + ']' as result