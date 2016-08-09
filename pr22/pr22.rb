# This problem does not have any particular algorithmic complexity. The approach
# is to:
# 1) read in the file containing the string
# 2) clean up the string and seperate by commas into an array
# 3) sort the array alphabetically
# 4) with the index available, map over the names in the array, and
# 5) for each element, map over the letters in the element and replace them with a value
# 6) then take the sum of that value multiplied by the index + 1, return that from the
#    outer map, and you now have an array of scores as required by the problem
# 7) take the sum of the whole array for the final value

def euler
  # 1) read in the file containing the string
  raw_input = File.read("./p022_names.txt")

  # 2) clean up the string and seperate by commas into an array
  cleaned_input = raw_input.gsub("\"", '')
  name_array = cleaned_input.split(',')

  # 3) sort the array alphabetically
  sorted_array = name_array.sort

  # 4) with the index available, map over the names in the array, and
  score_array = sorted_array.each_with_index.map do |name, i|

    # 5) for each element, map over the letters in the element and replace them with a value
    name_values = name.chars.map { |char| char.ord - 64 }

    # 6) then take the sum of that value multiplied by the index + 1, return that from the
    #    outer map, and you now have an array of scores as required by the problem
    name_value = name_values.reduce(&:+)
    name_value * (i + 1) # note Ruby's implicit return from block, as with functions
  end

  # 7) take the sum of the whole array for the final value
  score_array.reduce(&:+)
end

# print out the return value to the console
p euler

#################################### GOLF TIME #########################################
# here is an entertaining minimalist version to show off Ruby's coolness
# note that Dan would take away your keyboard if you tried submitting this as project code
def euler_golf
  File.read("./p022_names.txt").gsub("\"", '').split(',').sort.each_with_index.map { |n, i| (i + 1 ) * n.chars.map { |c| c.ord - 64 }.reduce(&:+) }.reduce(&:+)
end

p euler_golf
