﻿window.onload = function () {
    document.getElementById("pdfGenerate")
        .addEventListener("click", () => {
            const invoice = this.document.getElementById("table")
            console.log(invoice);
            console.log(window);
            var opt = {
                margin: 0.1,
                filename: 'table.pdf',
                image: { type: 'jpeg', quality: 0.98 },
                pagebreak: { mode: ['avoid-all', 'css', 'legacy'] },
                jsPDF: { unit: 'in', format: [8.5, 11], orientation: 'landscape', compressPDF: true }
            };
            html2pdf().from(invoice).set(opt).save();
        })
    document.getElementById("pdfGenerate").click();
}

function myAlert() {
    alert("PDF Sucessfuly Generated!");
}