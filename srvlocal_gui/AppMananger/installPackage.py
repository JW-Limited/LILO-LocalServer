
import zipfile
import os
import sys
import tkinter as tk
from tkinter import filedialog
from tkinter import ttk
from threading import Thread

class ZipExtractor:
    def __init__(self, zip_file_path=None, output_directory=None):
        self.zip_file_path = zip_file_path
        self.output_directory = output_directory
        self.progress_var = None
        self.progress_bar = None
        self.cancel_button = None
        self.cancelled = False
        self.root = None

    def is_valid_zip_file(self):
        try:
            with zipfile.ZipFile(self.zip_file_path, 'r') as zip_ref:
                return zip_ref.testzip() is None
        except zipfile.BadZipFile:
            return False

    def extract_zip_file(self):
        with zipfile.ZipFile(self.zip_file_path, 'r') as zip_ref:
            total_files = len(zip_ref.infolist())
            extracted_files = 0
            for file in zip_ref.infolist():
                if self.cancelled:
                    break
                zip_ref.extract(file, self.output_directory)
                extracted_files += 1
                self.progress_var.set(extracted_files / total_files)
        self.cleanup()

    def start_extraction(self):
        if not self.is_valid_zip_file():
            print(f"'{self.zip_file_path}' is not a valid Updatefile.")
            sys.exit(1)

        if not os.path.exists(self.output_directory):
            os.makedirs(self.output_directory)

        self.root = tk.Tk()
        self.root.title("Updater")
        self.root.geometry("500x200")
        self.root.resizable(False, False)
        self.root.configure(bg="#F5F5F5")

        title_label = tk.Label(self.root, text="Extracting files...", font=("Arial", 16), bg="#F5F5F5")
        title_label.grid(row=0, column=0, columnspan=2, pady=10)

        self.progress_var = tk.DoubleVar()
        self.progress_bar = ttk.Progressbar(self.root, variable=self.progress_var, maximum=1, length=300, mode="determinate")
        self.progress_bar.grid(row=1, column=0, columnspan=2, pady=10)

        self.cancel_button = tk.Button(self.root, text="Cancel", font=("Arial", 12), bg="#0078D7", fg="white", command=self.cancel_extraction)
        self.cancel_button.grid(row=2, column=0, pady=10)

        Thread(target=self.extract_zip_file).start()

        self.root.protocol("WM_DELETE_WINDOW", self.cleanup)
        self.root.mainloop()

    def cancel_extraction(self):
        self.cancelled = True
        self.cleanup()

    def cleanup(self):
        if self.progress_bar:
            self.progress_bar.destroy()
        if self.cancel_button:
            self.cancel_button.destroy()
        if self.root:
            self.root.destroy()

def browse_zip_file(entry):
    file_path = filedialog.askopenfilename(filetypes=[("Zip files", "*.zip")])
    entry.delete(0, tk.END)
    entry.insert(0, file_path)

def browse_output_directory(entry):
    directory_path = filedialog.askdirectory()
    entry.delete(0, tk.END)
    entry.insert(0, directory_path)

def main():
    if len(sys.argv) == 3:
        extractor = ZipExtractor(sys.argv[1], sys.argv[2])
        extractor.start_extraction()
        return

    root = tk.Tk()
    root.title("Zip Extractor")
    root.geometry("500x200")
    root.configure(bg="#F5F5F5")

    zip_file_label = tk.Label(root, text="Zip file:", font=("Arial", 12), bg="#F5F5F5")
    zip_file_label.grid(row=0, column=0, sticky="e", padx=10, pady=10)
    zip_file_entry = tk.Entry(root, width=50, font=("Arial", 12))
    zip_file_entry.grid(row=0, column=1, padx=10, pady=10)
    zip_file_button = tk.Button(root, text="Browse", font=("Arial", 12), bg="#0078D7", fg="white", command=lambda: browse_zip_file(zip_file_entry))
    zip_file_button.grid(row=0, column=2, padx=10, pady=10)

    output_dir_label = tk.Label(root, text="Output directory:", font=("Arial", 12), bg="#F5F5F5")
    output_dir_label.grid(row=1, column=0, sticky="e", padx=10, pady=10)
    output_dir_entry = tk.Entry(root, width=50, font=("Arial", 12))
    output_dir_entry.grid(row=1, column=1, padx=10)
    output_dir_button = tk.Button(root, text="Browse", font=("Arial", 12), bg="#0078D7", fg="white", command=lambda: browse_output_directory(output_dir_entry))
    output_dir_button.grid(row=1, column=2, padx=10, pady=10)

    extract_button = tk.Button(root, text="Extract", font=("Arial", 12), bg="#0078D7", fg="white", command=lambda: ZipExtractor(zip_file_entry.get(), output_dir_entry.get()).start_extraction())
    extract_button.grid(row=2, column=1, pady=10)

    root.mainloop()

if __name__ == "__main__":
    main()
