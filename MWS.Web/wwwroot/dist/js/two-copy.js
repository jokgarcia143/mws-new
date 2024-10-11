window.onload = function () {
    document.getElementById("pdfGenerate")
        .addEventListener("click", () => {
            const invoice = this.document.getElementById("table")
            console.log(invoice);
            console.log(window);
            var opt = {
                html2canvas: {
                    dpi: 96,
                    scale: 4,
                    letterRendering: true,
                    useCORS: true
                },
                margin: 0.1,
                filename: 'PrintReceiving.pdf',
                image: { type: 'jpeg', quality: 0.95 },
                pagebreak: { mode: ['avoid-all', 'css', 'legacy'] },
                jsPDF: { unit: 'in', format: [8.5, 11], orientation: 'portrait' }
            };
            html2pdf().from(invoice).set(opt).save();
        })
    document.getElementById("pdfGenerate").click();
    
}
function myAlert() {
    alert("PDF Sucessfuly Generated!");
}