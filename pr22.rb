def euler
  names = File.read("./p022_names.txt").gsub("\"", '').split(',').sort
  numbers = names.each_with_index.map do |name, i|
    (i + 1 ) * name.chars.map { |c| c.ord - 64 }.reduce(&:+)
  end
end

euler
