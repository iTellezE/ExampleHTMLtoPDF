const puppeteer = require('puppeteer');

module.exports = async function (callback, page) {
    // Create a browser instance
    const browser = await puppeteer.launch();

    // Create a new page
    const page = await browser.newPage();

    // Website URL to export as pdf
    const website_url = 'https://new-mtn.eleva.school/#/auth/login?returnUrl=%2F';
    //const website_url = 'https://www.bannerbear.com/blog/how-to-download-images-from-a-website-using-puppeteer/'; 


    // Open URL in current page
    await page.goto(website_url, { waitUntil: 'networkidle0' });

    //To reflect CSS used for screens instead of print
    await page.emulateMediaType('screen');

    // Downlaod the PDF
    const pdf = await page.pdf({
        path: 'result.pdf',
        margin: { top: '100px', right: '50px', bottom: '100px', left: '50px' },
        printBackground: true,
        format: 'A4',
    });

    // Close the browser instance
    await browser.close();
};

//(async () => {

//    // Create a browser instance
//    const browser = await puppeteer.launch();

//    // Create a new page
//    const page = await browser.newPage();

//    // Website URL to export as pdf
//    const website_url = 'https://new-mtn.eleva.school/#/auth/login?returnUrl=%2F';
//    //const website_url = 'https://www.bannerbear.com/blog/how-to-download-images-from-a-website-using-puppeteer/'; 


//    // Open URL in current page
//    await page.goto(website_url, { waitUntil: 'networkidle0' });

//    //To reflect CSS used for screens instead of print
//    await page.emulateMediaType('screen');

//    // Downlaod the PDF
//    const pdf = await page.pdf({
//        path: 'result.pdf',
//        margin: { top: '100px', right: '50px', bottom: '100px', left: '50px' },
//        printBackground: true,
//        format: 'A4',
//    });

//    // Close the browser instance
//    await browser.close();
//})();