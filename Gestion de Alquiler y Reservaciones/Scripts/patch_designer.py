import re

file_path = "ContratosForm.Designer.cs"

with open(file_path, 'r', encoding='utf-8') as f:
    content = f.read()

# Define new controls
controls = [
    # Apartamento
    {"name": "cmbNumeroDepartamento", "type": "ComboBox", "parent": "pnlFormApartamento", "x": 395, "y": 252, "w": 180, "h": 23, "text": "", "lbl_text": "Número de Departamento", "items": ["1", "2", "3", "4"]},
    
    # Local
    {"name": "cmbNumeroLocal", "type": "ComboBox", "parent": "pnlFormLocal", "x": 24, "y": 360, "w": 200, "h": 23, "text": "", "lbl_text": "Número de Local", "items": [str(i) for i in range(1, 19)]},
    
    # Sala
    {"name": "cmbSeleccionSala", "type": "ComboBox", "parent": "pnlFormSala", "x": 24, "y": 70, "w": 260, "h": 23, "text": "", "lbl_text": "Selección", "items": ["Auditorio Los Zorzales", "Sala de Juntas"]},
    {"name": "txtNombreArrendatarioS", "type": "TextBox", "parent": "pnlFormSala", "x": 308, "y": 70, "w": 260, "h": 23, "text": "", "lbl_text": "Nombre del Arrendatario"},
    {"name": "txtIdentidadS", "type": "TextBox", "parent": "pnlFormSala", "x": 24, "y": 128, "w": 220, "h": 23, "text": "", "lbl_text": "Número de Identidad"},
    {"name": "txtNumeroHorasS", "type": "TextBox", "parent": "pnlFormSala", "x": 308, "y": 128, "w": 220, "h": 23, "text": "", "lbl_text": "Número de Horas"},
    {"name": "dtpFechaArrendamientoS", "type": "DateTimePicker", "parent": "pnlFormSala", "x": 24, "y": 186, "w": 220, "h": 23, "text": "", "lbl_text": "Fecha de Arrendamiento"},
    {"name": "dtpHoraInicioS", "type": "DateTimePicker", "parent": "pnlFormSala", "x": 308, "y": 186, "w": 220, "h": 23, "text": "", "lbl_text": "Hora de Inicio", "format": "Time"},
    {"name": "dtpHoraFinalS", "type": "DateTimePicker", "parent": "pnlFormSala", "x": 24, "y": 244, "w": 220, "h": 23, "text": "", "lbl_text": "Hora Final", "format": "Time"},
    {"name": "txtPrecioHoraS", "type": "TextBox", "parent": "pnlFormSala", "x": 308, "y": 244, "w": 220, "h": 23, "text": "", "lbl_text": "Precio por Hora"},
    {"name": "cmbCantidadPersonasS", "type": "ComboBox", "parent": "pnlFormSala", "x": 24, "y": 302, "w": 220, "h": 23, "text": "", "lbl_text": "Cantidad de Personas", "items": ["100", "200"], "enabled": False},

    # Casa
    {"name": "txtNombreHuespedC", "type": "TextBox", "parent": "pnlFormCasa", "x": 24, "y": 70, "w": 260, "h": 23, "text": "", "lbl_text": "Nombre del Huésped"},
    {"name": "txtIdentidadHuespedC", "type": "TextBox", "parent": "pnlFormCasa", "x": 308, "y": 70, "w": 260, "h": 23, "text": "", "lbl_text": "Identidad del Huésped"},
    {"name": "cmbSeleccionCasa", "type": "ComboBox", "parent": "pnlFormCasa", "x": 24, "y": 128, "w": 220, "h": 23, "text": "", "lbl_text": "Selección", "items": ["Barrio el Paraiso, Tela", "Las Peñitas"]},
    {"name": "dtpFechaInicialC", "type": "DateTimePicker", "parent": "pnlFormCasa", "x": 308, "y": 128, "w": 220, "h": 23, "text": "", "lbl_text": "Fecha Inicial"},
    {"name": "dtpFechaFinalC", "type": "DateTimePicker", "parent": "pnlFormCasa", "x": 24, "y": 186, "w": 220, "h": 23, "text": "", "lbl_text": "Fecha Final"},
    {"name": "dtpHoraInicialC", "type": "DateTimePicker", "parent": "pnlFormCasa", "x": 308, "y": 186, "w": 220, "h": 23, "text": "", "lbl_text": "Hora Inicial", "format": "Time"},
    {"name": "txtDiasC", "type": "TextBox", "parent": "pnlFormCasa", "x": 24, "y": 244, "w": 220, "h": 23, "text": "", "lbl_text": "Días"},
    {"name": "txtTarifaC", "type": "TextBox", "parent": "pnlFormCasa", "x": 308, "y": 244, "w": 220, "h": 23, "text": "", "lbl_text": "Tarifa"},
    {"name": "txtTotalPersonasC", "type": "TextBox", "parent": "pnlFormCasa", "x": 24, "y": 302, "w": 220, "h": 23, "text": "", "lbl_text": "Total Personas"}
]

# Generate strings
instantiations = []
adds = []
props = []
decls = []

for c in controls:
    lbl_name = "lbl" + c['name'][3:]
    instantiations.append(f"            this.{lbl_name} = new System.Windows.Forms.Label();")
    instantiations.append(f"            this.{c['name']} = new System.Windows.Forms.System.Windows.Forms.{c['type']}();")
    
    adds.append(f"            this.{c['parent']}.Controls.Add(this.{lbl_name});")
    adds.append(f"            this.{c['parent']}.Controls.Add(this.{c['name']});")
    
    props.append(f"""            // 
            // {lbl_name}
            // 
            this.{lbl_name}.AutoSize = true;
            this.{lbl_name}.Font = new System.Drawing.Font("Montserrat", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.{lbl_name}.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.{lbl_name}.Location = new System.Drawing.Point({c['x']}, {c['y'] - 20});
            this.{lbl_name}.Name = "{lbl_name}";
            this.{lbl_name}.Size = new System.Drawing.Size(150, 17);
            this.{lbl_name}.TabIndex = 0;
            this.{lbl_name}.Text = "{c['lbl_text']}";
            // 
            // {c['name']}
            // 
            this.{c['name']}.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.{c['name']}.Location = new System.Drawing.Point({c['x']}, {c['y']});
            this.{c['name']}.Name = "{c['name']}";
            this.{c['name']}.Size = new System.Drawing.Size({c['w']}, {c['h']});
            this.{c['name']}.TabIndex = 0;""")
    
    if c['type'] == 'ComboBox':
        items_str = ", ".join(f'"{i}"' for i in c.get('items', []))
        props.append(f"            this.{c['name']}.Items.AddRange(new object[] {{ {items_str} }});")
        props.append(f"            this.{c['name']}.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;")
        if c.get('enabled', True) == False:
            props.append(f"            this.{c['name']}.Enabled = false;")
    elif c['type'] == 'DateTimePicker':
        if c.get('format') == 'Time':
            props.append(f"            this.{c['name']}.Format = System.Windows.Forms.DateTimePickerFormat.Time;")
            props.append(f"            this.{c['name']}.ShowUpDown = true;")
        else:
            props.append(f"            this.{c['name']}.Format = System.Windows.Forms.DateTimePickerFormat.Short;")
    elif c['type'] == 'TextBox':
        props.append(f"            this.{c['name']}.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;")

    decls.append(f"        private System.Windows.Forms.Label {lbl_name};")
    decls.append(f"        private System.Windows.Forms.{c['type']} {c['name']};")

# Find sections and replace
init_index = content.find("private void InitializeComponent()")
inst_index = content.find("this.pnlCuerpo.SuspendLayout();")

if inst_index != -1:
    content = content[:inst_index] + "\n".join(instantiations) + "\n" + content[inst_index:]

# Adds
for panel in ["pnlFormApartamento", "pnlFormLocal", "pnlFormCasa", "pnlFormSala"]:
    add_str = "\n".join([a for a in adds if panel in a])
    if add_str:
        target = f"this.{panel}.ResumeLayout(false);"
        if target in content:
            content = content.replace(target, add_str + f"\n            {target}")
        else:
            # Maybe the panel doesn't have resume layout, just inject before the general resume layout
            print(f"Warning: could not find resume layout for {panel}")

# Props
props_index = content.find("this.pnlCuerpo.ResumeLayout(false);")
if props_index != -1:
    content = content[:props_index] + "\n".join(props) + "\n" + content[props_index:]

# Decls
decls_index = content.rfind("}")
if decls_index != -1:
    decls_index2 = content.rfind("}", 0, decls_index - 1)
    if decls_index2 != -1:
        content = content[:decls_index2] + "\n".join(decls) + "\n" + content[decls_index2:]

content = content.replace("System.Windows.Forms.System.Windows.Forms.", "System.Windows.Forms.")

with open(file_path, 'w', encoding='utf-8') as f:
    f.write(content)

print("Designer updated.")
