sed -i .a "/%1/d" "tags"
rm 'tags.a'
ctags -a -f "tags" --c#-kinds=+p --fields=+iaS --extra=+q %2
gvim --servername %3 --remote-send ":UpdateTypesFileOnly<CR>"
