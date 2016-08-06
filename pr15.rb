def euler(size)
  a = [1]
  euler(size - 1).slice(1, size - 1).each { |el| a.push(a.last + el) } unless size == 1
  a.push(a.last * 2)
end

p euler(ARGV[0].to_i).last
