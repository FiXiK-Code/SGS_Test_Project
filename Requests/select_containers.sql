SELECT '[' + (
    select concat('{',
    '"ID":',ID,',',
    '"Number":',[Number],',',
    '"Type":',[Type],',',
    '"Length":',[Length],',',
    '"Width":',[Width],',',
    '"Height":',[Height],',',
    '"IsEmpty":',[IsEmpty],',',
    '"ArrivalDate":','"',CONVERT(varchar, ArrivalDate, 104),'"',
    '},')
    as [data()]
    from Containers
    for xml PATH('') 
) + ']' as result