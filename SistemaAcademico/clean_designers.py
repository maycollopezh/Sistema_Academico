import os
import re

def process_file(designer_path):
    cs_path = designer_path.replace(".Designer.cs", ".cs")
    
    if not os.path.exists(designer_path) or not os.path.exists(cs_path):
        return False
        
    with open(designer_path, "r", encoding="utf-8") as f:
        designer_code = f.read()
        
    # Find InitializeComponent
    match = re.search(r'private void InitializeComponent\(\)\s*\{([\s\S]*?)\n\s*\}\s*\n\s*#endregion', designer_code)
    if not match:
        return False
        
    init_body = match.group(1)
    
    # Check if there is anything complex (like { })
    if "{" not in init_body and "=>" not in init_body:
        return False # No need to refactor if it's already clean or simple
        
    # Find SuspendLayout and ResumeLayout
    suspend_idx = init_body.find("this.SuspendLayout();")
    resume_idx = init_body.rfind("this.ResumeLayout(false);")
    
    if suspend_idx == -1 or resume_idx == -1:
        # Maybe it's already refactored manually
        return False
        
    suspend_end = suspend_idx + len("this.SuspendLayout();")
    extracted_code = init_body[suspend_end:resume_idx].strip()
    
    if not extracted_code:
        return False
        
    # Rewrite InitializeComponent
    new_init_body = init_body[:suspend_end] + "\n            this.ResumeLayout(false);"
    new_designer_code = designer_code[:match.start(1)] + new_init_body + designer_code[match.end(1):]
    
    with open(designer_path, "w", encoding="utf-8") as f:
        f.write(new_designer_code)
        
    # Now process the .cs file
    with open(cs_path, "r", encoding="utf-8") as f:
        cs_code = f.read()
        
    if "ConfigurarInterfaz()" in cs_code:
        return False # Already processed
        
    # Find constructor
    class_name = os.path.basename(cs_path).replace(".cs", "")
    cons_match = re.search(r'public ' + class_name + r'\(\)\s*\{([\s\S]*?)InitializeComponent\(\);', cs_code)
    
    if not cons_match:
        # Constructor might have arguments? Let's assume standard
        cons_match = re.search(r'InitializeComponent\(\);', cs_code)
        if not cons_match:
            return False
            
    # Insert ConfigurarInterfaz() after InitializeComponent();
    insert_idx = cons_match.end()
    cs_code = cs_code[:insert_idx] + "\n            ConfigurarInterfaz();" + cs_code[insert_idx:]
    
    # Insert the new method at the end of the class (before the last two closing braces)
    class_close_idx = cs_code.rfind("}")
    class_close_idx = cs_code.rfind("}", 0, class_close_idx)
    
    method_code = f"""
        private void ConfigurarInterfaz()
        {{
            {extracted_code}
        }}
"""
    cs_code = cs_code[:class_close_idx] + method_code + cs_code[class_close_idx:]
    
    with open(cs_path, "w", encoding="utf-8") as f:
        f.write(cs_code)
        
    print(f"Processed: {class_name}")
    return True

base_dir = r"c:\Users\Hp\Documents\Portafolio Base de Datos II\Sistema_Academico\SistemaAcademico\UI"
for root, dirs, files in os.walk(base_dir):
    for file in files:
        if file.endswith(".Designer.cs"):
            # Exclude already fixed files
            if file in ["FrmLogin.Designer.cs", "FrmPrincipalAdmin.Designer.cs", "FrmPrincipalDocente.Designer.cs", "FrmPrincipalEstudiante.Designer.cs"]:
                continue
            process_file(os.path.join(root, file))
