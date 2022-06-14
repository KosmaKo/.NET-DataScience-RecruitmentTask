#1. Create function to find longest string in the sequence
#• Parameters: list of string
#• What would be complexity of that function for the N items? 

#complexity of this function is N as we need to iterate over the list only once
def longestString(list):
    max=""
    for s in list:
        if len(s) > len(max):
            max = s
    return max
    
#2. Create function to merge two dictionaries and get maximum of the value in case of conflict
#• Parameters: dict[string, int], dict[string, int] 
def mergeDictionaries(a, b):
    common_keys = {}
    for i in a.keys():
        for j in b.keys():
            if i == j:
                if a[j] > b[j]:
                    common_keys[j]=a[j]
                else:
                    common_keys[j]=b[j]
    return {**a, **b, **common_keys}
    
#Examples/Testing  
lista = {"1","2","3","4","5","6","7","234","342","12","3"}
print(f'Longest string is: {longestString(lista)}')

dict1 = {'a': 1, 'b': 2,'c': 30,'d': 4,'e': 5}
dict2 = {'a': 10, 'b': 20,'c': 3,'dd': 40,'ee': 50}
print(mergeDictionaries(dict1,dict2))


#3. Is there anything what could be improved in below examples?
#• Example 1:
#def get_biggest_item(data):
# data_sorted = sorted(data)
# count = len(data_sorted)
# return data[count – 1] 

#Getting the biggest item doesnt requite sorting the data,
#if we know that the data is not sorted we can just iterate throughout the set and find it with N complexity,
#similiar to longestString function I made

#Example 2:
#def join_names(first_names, last_names):
# result = ()
# count = len(first_names)
# for i in range(count):
# result.append(first_names[i] + last_names[i])
# return result 

#I think join_names function doesn't work properly, as it will just mash the first_name and last_name together, without any separator.
#It would be best to either use a tuple or add whitespace between first and last name.
#Additionally we dont have to declare count we can just do a loop over two lists using zip
# for(i,j) in zip(first_names, last_names):
#   result.append(i,j)

#this will make a tuple and iterate over both lists until one or both of them are exhausted
    