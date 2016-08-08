# This is a recursive approach to problem 15 that builds out an array of the number
# of paths from a given point, to the bottom right corner.
# This algorithm takes advantage of the fact that the lattices are composible - that
# is, a 3 by 3 lattice is the 2 by 2 lattice, just with an extra column on the left
# and an extra row on top. This algorithm works for any positive integer square
# shaped lattice.
#
# EXAMPLE:
#
# 2 by 2 lattice
#
#   ._._.
#   |_|_|
#   |_|_|
#
# Paths from each corner to the bottom right:
#
#   6 3 1
#   3 2 1
#   1 1 0
#
# 3 by 3 lattice
# ._._._.
# |_|_|_|
# |_|_|_|
# |_|_|_|
#
# Paths from each corner to the bottom right:
# 
# 20 10 4  1
# 10 6  3  1
# 4  3  2  1
# 1  1  1  1
#
# Note that the 2 by 2 lattice is contained within the 3 by 3 lattice.
def euler(size)
  #  since our solution is recursive, we need a final escape condition
  if size == 1
    return [1, 2] # return will short circuit the function here
  end
  # note that in Ruby this can also be written as a one liner:
  # return [1, 2] if size == 1

  # for each extra row and column in the lattice, the corner positions only have
  # one path to the bottom right (either all the way down or all the way right)
  euler_array = [0]

  # this is where we recurse, building out each column of the array
  smaller_euler = euler(size - 1)

  # the algorithm for the solution is that each row (or column) is the smaller row
  # added sequentially together from 0. So, to get row 6, 3, 1 from 3, 2, 1:
  # take 0 + 1 = 1 as the smallest value, then take that 1 plus 2 to get 3 as the
  # second smallest value, then take 3 plus 3 to get the final value 6.
  smaller_euler.each do |el|
    euler_array.push(euler_array.last + el)
  end

  # since we so far cumulative added the results for either row OR column, rather
  # than doing the other we take advantage of the square's symmetry and just use
  # double the last number so far stored
  euler_array.push(euler_array.last * 2)
end

# ARGV[n] is Ruby's syntax for accessing the nth optional argument when running a script
# from the command line. So running `ruby pr15.rb 5` will provide the string argument
# "5", which I convert to an integer for use in the function
# also note my function returns an array, so I call .last to access the result
p euler(ARGV[0].to_i).last

#################################### GOLF TIME #########################################
# here is an entertaining minimalist version to show off Ruby's coolness
# note that Dan would take away your keyboard if you tried submitting this as project code
def euler_golf(size)
  a = [1]
  euler_golf(size - 1).slice(1, size - 1).each { |el| a.push(a.last + el) } unless size == 1
  a.push(a.last * 2)
end

p euler_golf(ARGV[0].to_i).last
