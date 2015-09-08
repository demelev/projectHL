"
"Tags settings
"  -->
let g:TagHighlightSettings['UserLibraryDir'] = getcwd()

let g:thirdTags   = ['Library']

let g:excludeDirs = ['Library/',
            \'ProjectSettings/']

let g:projectTagsList = ['Assets/']

"let g:ctagsOptions = '--tag-relative=yes -R -f .vim/tags --c++-kinds=+p --fields=+iaS --extra=+q '
"let g:ctagsOptions = '--tag-relative=yes -R -f .vim/tags --c#-kinds=+p --fields=+iaS --extra=+q '
let g:ctagsOptions = '-R --c\#-kinds=+p --fields=+iaS --extra=+q '
"  <--
let prog = 'set makeprg='.g:projectDir.'\.vim\buildProject.bat'
execute prog

set errorformat=\ %#%f(%l):\ %m
set errorformat+=\ %#%f(%l\,%c):\ %m

"call ExtractSnips(".vim\snippets", "cpp")
set wildignore+=*\\.git\\*,*\\.hg\\*,*\\.svn\\*
map <c-p> :CtrlPRoot<cr>
set hidden
map <F6>  :UpdateMainTags<cr>
