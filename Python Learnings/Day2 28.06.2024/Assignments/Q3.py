#Sort score and name of players print the top 10
from operator import itemgetter, attrgetter

a=[
    ('b',10),
    ('y',10),
    ('c',10),
    ('d',9),
    ('e',12),
    ('f',89),
    ('g',16),
    ('h',74),
    ('x',34),
    ('k',37),
    ('x',74),
    ('r',34),
    ('j',37)
]

def param_sort(a):
    return (a[1],a[0])

def sort_score_name(score_list):
    # return score_list.sort(key=param_sort)
    return score_list.sort(key=itemgetter(0,1))

sort_score_name(a)
print(a[:10])