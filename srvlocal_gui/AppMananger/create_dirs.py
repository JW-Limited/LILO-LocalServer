import os
import sys
import re

# Define the regex pattern for valid directory names (only letters, digits, spaces, underscores and hyphens are allowed)
VALID_DIR_PATTERN = re.compile(r'^[a-zA-Z0-9\s_-]+$')

# Define a list of reserved words that can't be used as directory names
RESERVED_WORDS = ['con', 'prn', 'aux', 'nul', 'com1', 'com2', 'com3', 'com4', 'com5', 'com6', 'com7', 'com8', 'com9', 'lpt1', 'lpt2', 'lpt3', 'lpt4', 'lpt5', 'lpt6', 'lpt7', 'lpt8', 'lpt9']

# Parse command line arguments
if len(sys.argv) < 2 or sys.argv[1] in ['-h', '--help']:
    print("""Usage: python create_dirs.py [OPTIONS] <directory_names>
Options:
  -h, --help               Show this help message and exit.
  -p, --parent <dir>       Specify the parent directory for the new directories.
  -m, --mode <mode>        Specify the permissions for the new directories (in octal).
  -r, --remove-on-error    Remove newly created directories if an error occurs.
  
Example: python create_dirs.py -p /tmp -m 755 mydir1/mydir2""")
    sys.exit(0)

parent_dir = os.getcwd()  # By default, create new directories in the current working directory
file_mode = 0o777  # By default, use the default file mode for the current user
remove_on_error = False

if len(sys.argv) >= 4 and (sys.argv[1] == '-p' or sys.argv[1] == '--parent'):
    parent_dir = sys.argv[2]
    if not os.path.isdir(parent_dir):
        print(f"Error: Parent directory '{parent_dir}' does not exist.")
        sys.exit(1)
    sys.argv.pop(1)
    sys.argv.pop(1)

if len(sys.argv) >= 4 and (sys.argv[1] == '-m' or sys.argv[1] == '--mode'):
    file_mode = int(sys.argv[2], 8)
    sys.argv.pop(1)
    sys.argv.pop(1)

if '--remove-on-error' in sys.argv:
    remove_on_error = True
    sys.argv.remove('--remove-on-error')

# Create directories based on the arguments
for arg in sys.argv[1:]:
    if not VALID_DIR_PATTERN.match(arg):
        print(f"Error: Invalid directory name '{arg}'. Only letters, digits, spaces, underscores, and hyphens are allowed.\n For more help start python create_dirs.py -h;--help")
    elif arg.lower() in RESERVED_WORDS:
        print(f"Error: Directory name '{arg}' is a reserved word and can't be used.\n For more help start python create_dirs.py -h;--help")
    else:
        dir_path = os.path.join(parent_dir, arg)
        try:
            os.makedirs(dir_path, mode=file_mode)
            print(f"Directory '{dir_path}' created successfully.")
        except FileExistsError:
            print(f"Directory '{dir_path}' already exists.")
        except Exception as e:
            print(f"Error creating directory '{dir_path}': {e}\n For more help start python create_dirs.py -h;--help")
        if remove_on_error:
            os.removedirs(dir_path) 
            print(f"Directory '{dir_path}' removed.")
