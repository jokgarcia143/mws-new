window.onload = function () {
    document.getElementById("pdfGenerate")
        .addEventListener("click", () => {
            const invoice = this.document.getElementById("waterbill")
            console.log(invoice);
            console.log(window);
            var opt = {
                margin: [20,20,20,20],
                autoPaging: 'text', 
                filename: 'WaterBill.pdf',
                image: { type: 'jpeg', quality: 0.98 },
                jsPDF: { unit: 'in', format: [8.5, 11], orientation: 'portrait' },
                html2canvas: {
                    allowTaint: true,
                    letterRendering: true,
                    logging: false,
                    scale: 0.4, // Adjust the scale to fit content
                }
            };
            html2pdf().from(invoice).set(opt).save();
        })
    document.getElementById("pdfGenerate").click();
}

function myAlert() {
    alert("PDF Sucessfuly Generated!");
}