<?php
error_reporting(E_ALL);
require_once 'simpletest/unit_tester.php';
require_once 'simpletest/reporter.php';
require_once 'simpletest/mock_objects.php';

class PhpLondonTestDrivenDevelopmentTestCase extends UnitTestCase {}

$test = new  PhpLondonTestCase;

if (TextReporter::inCli()) {
  require_once 'simpletest/ui/colortext_reporter.php';
  exit ($test->run(new ColorTextReporter()) ? 0 : 1);
}
$test->run(new HtmlReporter());

?>
